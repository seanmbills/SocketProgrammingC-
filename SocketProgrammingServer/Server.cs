using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

using SocketProgrammingUtilities;

namespace SocketProgrammingServer
{
    public class Server
    {
        /* buffer sizes -- immutable/readonly */
        private readonly int RCVBUFSIZE = 512;     /* the receive buffer size */
        private readonly int SNDBUFSIZE = 512;     /* the send buffer size */

        private static byte[] incomingData = new byte[1024];
        private static string incomingString;

        private List<User> users = new List<User>();

        private bool TransferFunds(User fromUser, Account fromAcct,
            User toUser, Account toAcct, double amount)
        {
            if (fromUser == null || fromAcct == null || toUser == null ||
                toAcct == null) return false;
            return fromUser.TransferFunds(fromAcct, toAcct, amount);
        }

        public bool TransferFunds(int acctIdFrom, int acctIdTo, int amount)
        {
            Account fromAcct = null;
            Account toAcct = null;
            User fromUser = null;
            User toUser = null;
            foreach (var user in users)
            {
                var temp = user.FindAccountFromId(acctIdFrom);
                if (temp != null) {
                    fromAcct = temp;
                    fromUser = user;
                }
                temp = user.FindAccountFromId(acctIdTo);
                if (temp != null) {
                    toAcct = temp;
                    toUser = user;
                }
            }
            return TransferFunds(fromUser, fromAcct, toUser, toAcct, amount);
        }

        public bool AddNewUser(string username, string password,
            string confirmPassword)
        {
            if (password != confirmPassword) return false;
            if (UsernameTaken(username)) return false;
            User newUser = new User(username, password);
            users.Add(newUser);
            return true;
        }

        public bool DeleteUser(string username, string password)
        {
            foreach (var user in users)
            {
                if (user.Username == username && user.CheckEqualPasswords(password))
                {
                    users.Remove(user);
                    return true;
                }
            }
            return false;
        }

        public bool UsernameTaken(string name)
        {
            foreach(var user in users)
            {
                if (user.Username == name) return true;
            }
            return false;
        }

        public static void StartServer()
        {
            try
            {
                // Establish the local endpoint for the socket.  
                // Dns.GetHostName returns the name of the   
                // host running the application.  
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

                // Create a TCP/IP socket.  
                Socket listener = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Bind the socket to the local endpoint and   
                // listen for incoming connections.
                BindAndListen(listener, localEndPoint);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void BindAndListen(Socket listener,
            IPEndPoint localEndPoint)
        {
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                // Start listening for connections.  
                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");

                    // Program is suspended while waiting for an incoming connection.  
                    Socket handler = listener.Accept();
                    incomingString = null;

                    // An incoming connection needs to be processed.  
                    while (true)
                    {
                        int bytesRec = handler.Receive(incomingData);
                        incomingString += Encoding.ASCII.GetString(incomingData, 0, bytesRec);
                        if (incomingString.IndexOf("<EOF>", StringComparison.Ordinal) > -1)
                        {
                            break;
                        }
                    }

                    // Show the data on the console.  
                    Console.WriteLine("Text received : {0}", incomingString);

                    // Echo the data back to the client.  
                    byte[] msg = Encoding.ASCII.GetBytes(incomingString);

                    handler.Send(msg);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();
        }

        public static void Main(string[] args)
        {
            StartServer();
        }
    }
}

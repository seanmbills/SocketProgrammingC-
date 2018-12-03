using System;
using System.Collections.Generic;

namespace SocketProgrammingC
{
    class Server
    {
        /* buffer sizes -- immutable/readonly */
        //private readonly int RCVBUFSIZE = 512;     /* the receive buffer size */
        //private readonly int SNDBUFSIZE = 512;     /* the send buffer size */

        //private int clientSocketNum;        /* the unique socket descripter # */

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

        public static void Main(string[] args)
        {

        }
    }
}

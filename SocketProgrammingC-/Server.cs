using System;

namespace SocketProgrammingC
{
    class Server
    {
        /* buffer sizes -- immutable/readonly */
        private readonly int RCVBUFSIZE = 512;     /* the receive buffer size */
        private readonly int SNDBUFSIZE = 512;     /* the send buffer size */

        private int clientSocketNum;        /* the unique socket descripter # */

        private User[] users;

        public static void Main(string[] args)
        {

        }
    }
}

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

        public static void Main(string[] args)
        {

        }
    }
}

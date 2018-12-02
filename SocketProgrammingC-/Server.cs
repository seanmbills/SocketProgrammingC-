using System;

namespace SocketProgrammingC
{
    class Server
    {
        /* buffer sizes -- immutable/readonly */
        private readonly int RCVBUFSIZE = 512;     /* the receive buffer size */
        private readonly int SNDBUFSIZE = 512;     /* the send buffer size */

        private int clientSocketNum;        /* the unique socket descripter # */

        private int mySavings;
        public int MySavings
        {
            get { return mySavings; }
            set { mySavings = value; }
        }
        private int myChecking;
        public int MyChecking
        {
            get { return myChecking; }
            set { myChecking = value; }
        }
        private int myRetirement;
        public int MyRetirement
        {
            get { return myRetirement; }
            set { myRetirement = value; }
        }
        private int myCollege;
        public int MyCollege
        {
            get { return myCollege; }
            set { myCollege = value; }
        }


        public static void Main(string[] args)
        {

        }
    }
}

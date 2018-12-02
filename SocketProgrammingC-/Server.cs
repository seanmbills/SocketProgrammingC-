using System;

namespace SocketProgramming
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

        private class TimeTracker
        {
            private DateTime timeOne;
            private DateTime timeTwo;
            private DateTime timeThree;
            private int withdrawals = 1;

            private int accountAccesses = 0;
            public int AccountAccesses
            {
                get { return accountAccesses; }
            }
            public void UpdateAccountAccesses()
            {
                accountAccesses++;
            }
            public void UpdateTimes()
            {
                if (timeOne == DateTime.MinValue)
                {
                    timeOne = DateTime.Now;
                    UpdateAccountAccesses();
                } else if (timeTwo == DateTime.MinValue)
                {
                    timeTwo = DateTime.Now;
                    UpdateAccountAccesses();
                } else if (timeThree == DateTime.MinValue)
                {
                    timeThree = DateTime.Now;
                    UpdateAccountAccesses();
                } else
                {

                }
            }
        }

        public static void Main(string[] args)
        {

        }
    }
}

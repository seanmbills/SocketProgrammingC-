using System;
namespace SocketProgrammingC
{
    public class TimeTracker
    {
        private DateTime timeOne;
        private DateTime timeTwo;
        private DateTime timeThree;

        private bool withdraw = true;
        public bool Withdraw
        {
            get { return withdraw; }
            set { withdraw = value; }
        }

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
            }
            else if (timeTwo == DateTime.MinValue)
            {
                timeTwo = DateTime.Now;
                UpdateAccountAccesses();
            }
            else if (timeThree == DateTime.MinValue)
            {
                timeThree = DateTime.Now;
                UpdateAccountAccesses();
            }
            else
            {
                timeOne = timeTwo;
                timeTwo = timeThree;
                timeThree = DateTime.Now;
            }
        }

    }
}

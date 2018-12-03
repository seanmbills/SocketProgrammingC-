using System;
namespace SocketProgrammingC
{
    public class TimeTracker
    {
        private DateTime timeOne;
        public DateTime TimeOne
        {
            get { return timeOne; }
        }

        private DateTime timeTwo;
        public DateTime TimeTwo
        {
            get { return timeTwo; }
        }

        private DateTime timeThree;
        public DateTime TimeThree
        {
            get { return timeThree; }
        }


        public void UpdateTimes()
        {
            if (timeOne == DateTime.MinValue)
            {
                timeOne = DateTime.Now;
            }
            else if (timeTwo == DateTime.MinValue)
            {
                timeTwo = DateTime.Now;
            }
            else if (timeThree == DateTime.MinValue)
            {
                timeThree = DateTime.Now;
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

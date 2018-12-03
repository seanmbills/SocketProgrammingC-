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


        public void UpdateTimes(DateTime time)
        {
            if (timeOne == DateTime.MinValue)
            {
                timeOne = time;
            }
            else if (timeTwo == DateTime.MinValue)
            {
                timeTwo = time;
            }
            else if (timeThree == DateTime.MinValue)
            {
                timeThree = time;
            }
            else
            {
                timeOne = timeTwo;
                timeTwo = timeThree;
                timeThree = time;
            }
        }

        public TimeTracker()
        {
            this.timeOne = DateTime.MinValue;
            this.timeTwo = DateTime.MinValue;
            this.timeThree = DateTime.MinValue;
        }

    }
}

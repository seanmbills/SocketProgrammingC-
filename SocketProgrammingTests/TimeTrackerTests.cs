using NUnit.Framework;
using System;
using SocketProgrammingC;

namespace SocketProgrammingTests
{
    [TestFixture()]
    public class TestTimeTracker
    {
        [Test()]
        public void Instantiate_Test()
        {
            Console.Write("Starting Instantiate TimeTracker test...");
            TimeTracker tT = new TimeTracker();
            Assert.IsTrue(tT.TimeOne.Equals(DateTime.MinValue), "Time One was: " + tT.TimeOne);
            Assert.IsTrue(tT.TimeTwo.Equals(DateTime.MinValue), "Time Two was: " + tT.TimeTwo);
            Assert.IsTrue(tT.TimeThree.Equals(DateTime.MinValue), "Time Three was: " + tT.TimeThree);
            Console.Write("Finished Instantiate_Test...");
        }

        [Test]
        public void UpdateTimesOne_Test()
        {
            Console.Write("Starting UpdateTimesOne_Test...");
            TimeTracker tT = new TimeTracker();
            DateTime time = DateTime.Now;
            tT.UpdateTimes(time);
            Assert.IsTrue(tT.TimeOne.Equals(time), "Time One was: " + tT.TimeOne);
            Console.Write("Finished UpdateTimesOne_Test...");
        }

        [Test]
        public void UpdateTimesTwo_Test()
        {
            Console.Write("Starting UpdateTimesTwo_Test...");
            TimeTracker tT = new TimeTracker();
            DateTime now = DateTime.Now;
            System.Threading.Thread.Sleep(100);
            DateTime future = DateTime.Now;
            tT.UpdateTimes(now);
            tT.UpdateTimes(future);
            Assert.IsTrue(tT.TimeOne.Equals(now), "Time One was: " + tT.TimeOne);
            Assert.IsTrue(tT.TimeTwo.Equals(future), "Time Two was: " + tT.TimeTwo);
            Console.Write("Finished UpdateTimesTwo_Test...");
        }

        [Test]
        public void UpdateTimesThree_Test()
        {
            Console.Write("Starting UpdateTimesThree_Test...");
            TimeTracker tT = new TimeTracker();
            DateTime one = DateTime.Now;
            System.Threading.Thread.Sleep(100);
            DateTime two = DateTime.Now;
            System.Threading.Thread.Sleep(100);
            DateTime three = DateTime.Now;
            tT.UpdateTimes(one);
            tT.UpdateTimes(two);
            tT.UpdateTimes(three);
            Assert.IsTrue(tT.TimeOne.Equals(one), "Time One was: " + tT.TimeOne);
            Assert.IsTrue(tT.TimeTwo.Equals(two), "Time Two was: " + tT.TimeTwo);
            Assert.IsTrue(tT.TimeThree.Equals(three), "Time Three was: " + tT.TimeThree);
            Console.Write("Finished UpdateTimesThree_Test...");
        }

        [Test]
        public void UpdateTimesFour_Test()
        {
            Console.Write("Starting UpdateTimesFour_Test...");
            TimeTracker tT = new TimeTracker();
            DateTime one = DateTime.Now;
            System.Threading.Thread.Sleep(100);
            DateTime two = DateTime.Now;
            System.Threading.Thread.Sleep(100);
            DateTime three = DateTime.Now;
            System.Threading.Thread.Sleep(100);
            DateTime four = DateTime.Now;
            tT.UpdateTimes(one);
            tT.UpdateTimes(two);
            tT.UpdateTimes(three);
            tT.UpdateTimes(four);
            Assert.IsTrue(tT.TimeOne.Equals(two), "Time One was: " + tT.TimeOne + " Two: " + two);
            Assert.IsTrue(tT.TimeTwo.Equals(three), "Time Two was: " + tT.TimeTwo + " Three: " + three);
            Assert.IsTrue(tT.TimeThree.Equals(four), "Time Three was: " + tT.TimeThree + " Four: " + four);
            Console.Write("Finished UpdateTimesFour_Test...");
        }
    }
}

using NUnit.Framework;
using System;
using SocketProgrammingUtilities;

namespace SocketProgrammingTests
{
    [TestFixture()]
    public class TransactionTest
    {
        [Test()]
        public void InstantiateNoTransfer_Test()
        {
            string desc = "Test desc";
            double amount = 100.00;
            DateTime time = DateTime.Now;
            Transaction t = new Transaction(desc, amount, time);
            Assert.IsTrue(desc.Equals(t.Description));
            Assert.IsTrue(amount.Equals(t.Amount));
            Assert.IsTrue(time.Equals(t.Time));
            Assert.IsTrue(t.FromTo.Equals(""));
            Assert.IsTrue(t.TransferAccountId.Equals(-1));
        }
    }
}

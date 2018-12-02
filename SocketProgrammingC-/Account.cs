using System;
namespace SocketProgrammingC
{
    public class Account
    {
        TimeTracker timeTracker = new TimeTracker();

        private int balance;
        public int Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        //private AccountType name;
        private string name;
        public string Name
        {
            get { return Name; }
            set { name = value; }
        }

        private readonly int accountId;
        public int AccountId
        {
            get { return accountId; }
        }

        public Account(int _balance, string _name, int accountId)
        {
            this.balance = _balance;
            this.name = _name;
            this.accountId = accountId;
        }
    }
}

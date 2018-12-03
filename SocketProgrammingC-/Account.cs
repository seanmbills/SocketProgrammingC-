using System;
using System.Collections.Generic;

namespace SocketProgrammingC
{
    public class Account
    {
        private TimeTracker timeTracker = new TimeTracker();
        private readonly User accountOwner;

        private List<AccountAction> historyList = new List<AccountAction>();

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

        private readonly int accountId;
        public int AccountId
        {
            get { return accountId; }
        }

        public Account(int _balance, string _name, int accountId, User accountOwner)
        {
            this.balance = _balance;
            this.name = _name;
            this.accountId = accountId;
            this.accountOwner = accountOwner;
        }

        public bool WithdrawFromAccount(int amount)
        {
            if (amount > this.balance) return false;
            if (amount < 0) return false;
            else
            {
                timeTracker.UpdateTimes();
                UpdateAccountAccesses();
                if (DateTime.Now.Ticks - timeTracker.TimeOne.Ticks < 60)
                {
                    Withdraw = false;
                }
                else
                {
                    this.balance -= amount;
                    Withdraw = true;
                }
                return withdraw;
            }
        }

        public void DepositToAccount(int amount)
        {
            this.balance += amount;
        }
    }
}

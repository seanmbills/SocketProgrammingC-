using System;
using System.Collections.Generic;

namespace SocketProgrammingUtilities
{
    public class Account
    {
        private TimeTracker timeTracker = new TimeTracker();
        private readonly User accountOwner;

        private List<Transaction> historyList = new List<Transaction>();

        private double balance;
        public double Balance
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

        public Account(double _balance, string _name, int accountId, User accountOwner)
        {
            this.balance = _balance;
            this.name = _name;
            this.accountId = accountId;
            this.accountOwner = accountOwner;
        }

        public bool WithdrawFromAccount(double amount, bool transfer)
        {
            if (amount > this.balance) return false;
            if (amount < 0) return false;
            else
            {
                timeTracker.UpdateTimes(DateTime.Now);
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
                if (Withdraw && !transfer) historyList.Add(new Transaction("Withdrawal", amount, DateTime.Now));
                return withdraw;
            }
        }

        public void DepositToAccount(double amount, bool transfer)
        {
            this.balance += amount;
            if (!transfer)
                historyList.Add(new Transaction("Deposit", amount, DateTime.Now));
        }

        public void AddTransferTransaction(double amount, int acctId, string fromTo)
        {
            historyList.Add(new Transaction("Transfer", amount, DateTime.Now, acctId, fromTo));
        }
    }
}

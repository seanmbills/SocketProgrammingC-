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

        private AccountType name;
        public string Name
        {
            get { return GetNameValue(name); }
            set { name = GetAccountType(value); }
        }

        public Account()
        {
            balance = int.MaxValue;
        }
        public Account(int _balance)
        {
            this.balance = _balance;
        }
        public Account(int _balance, string _name)
        {
            this.balance = _balance;
            Name = _name;
        }

        private string GetNameValue(AccountType nameType)
        {
            switch (nameType)
            {
                case AccountType.Savings:
                    return "Savings";
                case AccountType.Checking:
                    return "Checking";
                case AccountType.Retirement:
                    return "Retirement";
                case AccountType.College:
                    return "College";
                case AccountType.Other:
                    return "Other";
                default:
                    return "None";
            }
        }

        private AccountType GetAccountType(string _name)
        {
            switch (_name)
            {
                case "Savings":
                    return AccountType.Savings;
                case "Checking":
                    return AccountType.Checking;
                case "Retirement":
                    return AccountType.Retirement;
                case "College":
                    return AccountType.College;
                case "Other":
                    return AccountType.Other;
                default:
                    return AccountType.None;
            }
        }
    }
}

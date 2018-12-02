using System;
using System.Collections.Generic;
namespace SocketProgrammingC
{
    public class User
    {
        private string username;
        public string Username
        {
            get { return username;  }
            set { username = value; }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private List<Account> accounts;
        public List<Account> Accounts
        {
            get { return accounts; }
        }

        public bool AddNewAccount(string username, string password,
            int accountId, string accountName, int accountBalance)
        {
            if (this.username == username && this.password == password)
            {
                accounts.Add(new Account(accountBalance,
                    accountName, accountId));
                return true;
            }
            return false;
        }

        public bool RemoveAccount(string username, string password,
            int accountId)
        {
            bool found = false;
            if (this.username == username && this.password == password)
            {
                foreach (var acct in accounts)
                {
                    if (acct.AccountId == accountId)
                    {
                        accounts.Remove(acct);
                        found = true;
                    }
                }
                return found;
            }
            return false;
        }

        public bool UpdatePassword(string oldPassword, string newPassword)
        {
            if (oldPassword == password)
            {
                password = newPassword;
                return true;
            }
            return false;
        }

        public bool UpdateUsername(string oldUsername, string newUsername,
            string password)
        {
            if (this.password == password && this.username == oldUsername)
            {
                Username = newUsername;
                return true;
            }
            return false;
        }

        public User(string username, string password) {
            Username = username;
            Password = password;
        }
    }
}

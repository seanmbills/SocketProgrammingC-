using System;
using System.Collections.Generic;
using System.Security.Cryptography;

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
        private string Password
        {
            get { return password; }
            set { password = value; }
        }

        private List<Account> accounts = new List<Account>();
        public List<Account> Accounts
        {
            get { return accounts; }
        }

        public bool AddNewAccount(string username, string password,
            int accountId, string accountName, double accountBalance)
        {
            if (this.username == username && this.password == HashPassword(password))
            {
                foreach (var acct in accounts)
                {
                    if (acct.AccountId == accountId) return false;
                }
                accounts.Add(new Account(accountBalance,
                    accountName, accountId, this));
                return true;
            }
            return false;
        }

        public bool CloseAccount(string username, string password, int acctId)
        {
            if (username == this.username && HashPassword(password) == this.password)
            {
                return RemoveAccount(acctId);
            }
            return false;
        }

        private bool RemoveAccount(int accountId)
        {
            bool found = false;
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

        public bool TransferFunds(Account fromAcct, Account toAcct, double amount)
        {
            if (amount < 0) return false;
            if (fromAcct == null || toAcct == null) return false;
            if (amount > fromAcct.Balance) return false;
            bool successfulWithdraw = fromAcct.WithdrawFromAccount(amount, true);
            if (!successfulWithdraw) return false;
            toAcct.DepositToAccount(amount, true);
            fromAcct.AddTransferTransaction(amount, toAcct.AccountId, "to");
            toAcct.AddTransferTransaction(amount, fromAcct.AccountId, "from");
            return true;
        }

        public bool TransferFunds(int fromAcctId, int toAcctId, double amount)
        {
            Account fromAcct = FindAccountFromId(fromAcctId);
            Account toAcct = FindAccountFromId(toAcctId);
            return TransferFunds(fromAcct, toAcct, amount);
        }

        public Account FindAccountFromId(int id)
        {
            foreach (var acct in accounts)
            {
                if (acct.AccountId == id) return acct;
            }
            return null;
        }

        private bool AccountExists(int acctId)
        {
            foreach (var acct in accounts)
            {
                if (acct.AccountId == acctId) return true;
            }
            return false;
        }

        private string HashPassword(string _password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(_password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            return savedPasswordHash;
        }

        public bool CheckEqualPasswords(string checkPassword)
        {
            return HashPassword(checkPassword) == password;
        }

        public bool UpdatePassword(string oldPassword, string newPassword)
        {
            if (HashPassword(oldPassword) == HashPassword(password))
            {
                password = HashPassword(newPassword);
                return true;
            }
            return false;
        }

        public bool UpdateUsername(string oldUsername, string newUsername,
            string password)
        {
            if (this.password == HashPassword(password) && this.username == oldUsername)
            {
                Username = newUsername;
                return true;
            }
            return false;
        }

        public User(string username, string password) {
            Username = username;
            Password = HashPassword(password);
        }
    }
}

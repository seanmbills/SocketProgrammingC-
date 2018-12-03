using System;
using System.Globalization;

namespace SocketProgrammingC
{
    public class Transaction
    {
        private readonly string transactionDescription;
        public string Description
        {
            get { return transactionDescription; }
        }

        private readonly double transactionAmount;
        public double Amount
        {
            get { return transactionAmount; }
        }

        private readonly DateTime transactionTime;
        public DateTime Time
        {
            get { return transactionTime; }
        }

        private readonly int transferAccountId;
        public int TransferAccountId
        {
            get { return transferAccountId; }
        }

        private readonly string fromTo;
        public string FromTo
        {
            get { return FromTo; }
        }

        public Transaction(string desc, double amount, DateTime time)
        {
            this.transactionDescription = desc;
            this.transactionAmount = amount;
            this.transactionTime = time;
            this.transferAccountId = -1;
            this.fromTo = "";
        }

        public Transaction(string desc, double amount, DateTime time,
            int transferAcctId, string fromTo) : this(desc, amount, time)
        {
            this.transferAccountId = transferAcctId;
            this.fromTo = fromTo;
        }

        public override string ToString()
        {
            string output = "" + transactionDescription + " of "
                + transactionAmount.ToString("C", CultureInfo.CurrentCulture);
            if (transferAccountId > 0) output += " " + fromTo + " Acct. #"
                + transferAccountId; 
            output += " at " + transactionTime.ToString();
            return output;
        }
    }
}

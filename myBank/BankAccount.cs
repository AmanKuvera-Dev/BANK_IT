using System;
using System.Collections.Generic;
using System.Text;

namespace myBank
{
    public class BankAccount
    {
        public string Number { get; set; }

        public string Owner { get; set; }

        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach(var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }

        private static int accountNumberSeed = 1234567898;

        private List<Transaction> allTransactions = new List<Transaction>();

        public void BankAccountDeposit(decimal depAmt, string note)
        {
            if (depAmt <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(depAmt), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(depAmt,DateTime.Now, note, Number);
            allTransactions.Add(deposit);
        }

        public void BankAccountWithdraw(decimal withAmt, string note)
        {
            if (withAmt <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(withAmt), "Amount of withdrawal must be positive");
            }
            if (Balance - withAmt < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-withAmt, DateTime.Now, note, Number);
            allTransactions.Add(withdrawal);
        }

        public void BankAccountDetails(string name, decimal initialBalance)
        {
            this.Owner = name;
            BankAccountDeposit(initialBalance, "Initial Balance");
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }


        public string GetAccountHistory()
        {
            var report = new StringBuilder();
            report.AppendLine("Date\t\tAmount\tNote");
            foreach(var item in allTransactions)
            {
                report.AppendLine($"{ item.Date.ToShortDateString()}\t{ item.Amount}\t{ item.Notes}");

            }
            return report.ToString();
        }



    }
}

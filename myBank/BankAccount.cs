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

        public void BankAccountDeposit(decimal depAmt, string note, string name, string num)
        {
            try
            {
                if (depAmt <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(depAmt), "Amount of deposit must be positive");
                }
                var deposit = new Transaction(depAmt, DateTime.Now, note, Number);
                allTransactions.Add(deposit);
                Console.WriteLine($"Account {num} owned by {name} was credited with ${depAmt}");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            
        }

        public void BankAccountWithdraw(decimal withAmt, string note, string name, string num)
        {
            try
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
                Console.WriteLine($"Account {num} owned by {name} was credited with ${withAmt}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void BankAccountDetails(string name, decimal initialBalance)
        {
            this.Owner = name;
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
            Console.WriteLine($"Account {Number} was created for {Owner}");
            BankAccountDeposit(initialBalance, "Initial Balance", name, Number);
            
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

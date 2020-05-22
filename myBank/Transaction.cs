using System;
using System.Collections.Generic;
using System.Text;

namespace myBank
{
    class Transaction
    {
        public decimal Amount { get; }

        public DateTime Date { get; }

        public string Notes { get; }

        public string Name { get; }

        public string accNum { get; }


    public Transaction(decimal amt, DateTime date, string note, string num)
        {
            this.Date = date;
            this.Amount = amt;
            this.accNum = num;
            this.Notes = note;
        }
    }
}

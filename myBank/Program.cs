using System;
using System.Collections.Generic;

/*Initial Commit*/


namespace myBank
{
    class Program
    {
        
        public static void Main(string[] args)
        {
            List<BankAccount> allAccounts = new List<BankAccount>();
        void createAccount()
            {
                Console.WriteLine("\n Enter Owner's Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("\n Enter Initial Balance: ");
                string iniAmt = Console.ReadLine();
                var Account = new BankAccount();
                Account.BankAccountDetails(name, Convert.ToDecimal(iniAmt));
                allAccounts.Add(Account);
                Console.WriteLine($"Account {Account.Number} was created for {Account.Owner} with Balance: {Account.Balance} ");
                Console.ReadLine();
            }
            void depositAmount()
            {
                Console.WriteLine("\n Enter Owner's Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("\n Enter deposit amount: ");
                string depAmt = Console.ReadLine();
                Console.WriteLine("\n Enter deposit note: ");
                string dnote = Console.ReadLine();
                foreach (var item in allAccounts)
                {
                    if (item.Owner == name)
                    {
                        item.BankAccountDeposit(Convert.ToDecimal(depAmt), dnote);
                        Console.WriteLine($"Account {item.Number} was credited with ${item.Owner}");
                        Console.WriteLine($"Your Balance is: {item.Balance}");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Invalid Details! Deposit failed.\n\n");
                    }
                }

            }

            void withdrawAmount()
            {
                Console.WriteLine("\n Enter Owner's Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("\n Enter withdraw amount: ");
                string withAmt = Console.ReadLine();
                Console.WriteLine("\n Enter withdraw note: ");
                string withnote = Console.ReadLine();
                foreach (var item in allAccounts)
                {
                    if (item.Owner == name)
                    {
                        item.BankAccountWithdraw(Convert.ToDecimal(withAmt), withnote);
                        Console.WriteLine($"Account {item.Number} owned by {item.Owner} was credited with ${withAmt}");
                        Console.WriteLine($"Your Balance is: {item.Balance}");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Invalid Details! Withdrawal failed.\n\n");
                    }
                }
            }

            void displaySummary()
            {
                Console.WriteLine("\n Enter Owner's Name: ");
                string name = Console.ReadLine();
                foreach (var item in allAccounts)
                {
                    if (item.Owner == name)
                    {
                        
                        string rep = item.GetAccountHistory();
                        Console.WriteLine($"Account Summary:\n{rep}\n");
                        Console.WriteLine($"Your Balance is: {item.Balance}");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Invalid Details!\n\n");
                    }
                }
            }






            while (true)
            {
                Console.WriteLine("1. Create a new Account\n 2. Deposit Amount\n 3. Withdraw Amount\n 4. Display Summary ");
                string i = Console.ReadLine();
                int ch = Convert.ToInt32(i);
                switch (i)
                {
                    case "1": createAccount(); break;
                    case "2": depositAmount(); break;
                    case "3": withdrawAmount(); break;
                    case "4": displaySummary(); break;

                }

            }

        }
    }
}

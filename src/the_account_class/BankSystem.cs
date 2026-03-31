using System;

namespace TheAccountClass
{
    public enum MenuOption
    {
        Withdraw,
        Deposit,
        Print,
        Quit
    }

    public class BankSystem
    {
        public static void Main(string[] args)
        {
            Account myAccount = new Account("Jake's Account", 200000.00m);
            MenuOption option;
            
            do
            {
                option = ReadUserOption();
                switch (option)
                {
                    case MenuOption.Withdraw:
                        DoWithdraw(myAccount);
                        break;
                    case MenuOption.Deposit:
                        DoDeposit(myAccount);
                        break;
                    case MenuOption.Print:
                        DoPrint(myAccount);
                        break;
                    case MenuOption.Quit:
                        Console.WriteLine("Goodbye!");
                        break;
                }
            } while (option != MenuOption.Quit);
        }

        private static MenuOption ReadUserOption()
        {
            int optionInt = 0;
            bool isValid = false;
            do
            {
                Console.WriteLine("\n--- Banking Menu ---");
                Console.WriteLine("1. Withdraw");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Print");
                Console.WriteLine("4. Quit");
                Console.Write("Select an option (1-4): ");
                
                try
                {
                    string? input = Console.ReadLine();
                    optionInt = Convert.ToInt32(input);
                    if (optionInt >= 1 && optionInt <= 4)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid option. Please enter a number between 1 and 4.");
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            } while (!isValid);
            
            return (MenuOption)(optionInt - 1);
        }

        private static void DoDeposit(Account account)
        {
            Console.Write("Enter the amount to deposit: ");
            try
            {
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                if (account.Deposit(amount))
                {
                    Console.WriteLine("Deposit successful.");
                }
                else
                {
                    Console.WriteLine("Deposit failed. Amount must be positive.");
                }
            }
            catch
            {
                Console.WriteLine("Invalid amount. Deposit failed.");
            }
        }

        private static void DoWithdraw(Account account)
        {
            Console.Write("Enter the amount to withdraw: ");
            try
            {
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                if (account.Withdraw(amount))
                {
                    Console.WriteLine("Withdrawal successful.");
                }
                else
                {
                    Console.WriteLine("Withdrawal failed. Amount must be positive and not exceed balance.");
                }
            }
            catch
            {
                Console.WriteLine("Invalid amount. Withdrawal failed.");
            }
        }

        private static void DoPrint(Account account)
        {
            account.Print();
        }
    }
}

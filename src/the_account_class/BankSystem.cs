using System;

namespace TheAccountClass
{
    /// Enumerates the menu options available for the banking system.
    /// Values map to indices (Withdraw=0, Deposit=1, Print=2, Quit=3)
    /// to align with user choice (1-4).
    public enum MenuOption
    {
        Withdraw,
        Deposit,
        Print,
        Exit
    }

    // Handles user interaction and interacts with the Account class.
    public class BankSystem
    {
        // Initializes an account and runs the main menu loop.
        public static void Main(string[] args)
        {
            // Create a sample account
            Account myAccount = new Account("Jake's Account", 200000.00m);
            MenuOption option;
            
            // Loop until the user chooses to Quit
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
                    case MenuOption.Exit:
                        Console.WriteLine("Exiting application. Goodbye!");
                        break;
                }
            } while (option != MenuOption.Exit);
        }

        // Displays the menu and reads the user's choice.
        // Continues to prompt until a valid selection (1-4) is made.
        // returns The MenuOption selected by the user.
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
                Console.WriteLine("4. Exit");
                Console.Write("Select an option (1-4): ");
                
                try
                {
                    string? input = Console.ReadLine();
                    optionInt = Convert.ToInt32(input);
                    
                    // Validate choice is within range
                    if (optionInt >= 1 && optionInt <= 4)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Error: Please select a valid option (1-4).");
                    }
                }
                catch
                {
                    // Handles non-integer input
                    Console.WriteLine("Error: Please enter a numeric value.");
                }
            } while (!isValid);
            
            // Adjust to 0-based index for Enum mapping
            return (MenuOption)(optionInt - 1);
        }

        // Handles the deposit process by prompting for an amount and calling Account.Deposit.
        private static void DoDeposit(Account account)
        {
            Console.Write("Enter the amount to deposit: ");
            try
            {
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                if (account.Deposit(amount))
                {
                    Console.WriteLine("Success: Amount deposited.");
                }
                else
                {
                    Console.WriteLine("Failure: Deposit failed. Amount must be positive.");
                }
            }
            catch
            {
                Console.WriteLine("Error: Invalid numeric input for amount.");
            }
        }

        // Handles the withdrawal process by prompting for an amount and calling Account.Withdraw.
        private static void DoWithdraw(Account account)
        {
            Console.Write("Enter the amount to withdraw: ");
            try
            {
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                if (account.Withdraw(amount))
                {
                    Console.WriteLine("Success: Withdrawal complete.");
                }
                else
                {
                    Console.WriteLine("Failure: Withdrawal failed. Ensure amount is positive and balance is sufficient.");
                }
            }
            catch
            {
                Console.WriteLine("Error: Invalid numeric input for amount.");
            }
        }

        // Calls the account's print method to display information.
        private static void DoPrint(Account account)
        {
            account.Print();
        }
    }
}

using System;

namespace TheAccountClass
{
    /// Enumerates the menu options available for the banking system.
    /// Values map to indices (Withdraw=1, Deposit=2, Print=3, Transfer=4, AddAccount=5, Exit=6)
    /// to align with user choice (1-6).
    public enum MenuOption
    {
        Withdraw,
        Deposit,
        Print,
        Transfer,
        AddAccount,
        Exit
    }

    // Handles user interaction and interacts with the Account class.
    public class BankSystem
    {
        // Initializes an account and runs the main menu loop.
        public static void Main(string[] args)
        {
            Bank bank = new Bank();
            bank.AddAccount(new Account("Jake's Account", 200000.00m));
            bank.AddAccount(new Account("Alice's Account", 50000.00m));

            MenuOption option;

            do
            {
                option = ReadUserOption();
                switch (option)
                {
                    case MenuOption.Withdraw:
                        DoWithdraw(bank);
                        break;
                    case MenuOption.Deposit:
                        DoDeposit(bank);
                        break;
                    case MenuOption.Print:
                        DoPrint(bank);
                        break;
                    case MenuOption.Transfer:
                        DoTransfer(bank);
                        break;
                    case MenuOption.AddAccount:
                        DoAddAccount(bank);
                        break;
                    case MenuOption.Exit:
                        Console.WriteLine("Exiting application. Goodbye!");
                        break;
                }
            } while (option != MenuOption.Exit);
        }

        // Displays the menu and reads the user's choice.
        // Continues to prompt until a valid selection (1-6) is made.
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
                Console.WriteLine("3. Print Account Details");
                Console.WriteLine("4. Transfer");
                Console.WriteLine("5. Add new account");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option (1-6): ");

                try
                {
                    string? input = Console.ReadLine();
                    optionInt = Convert.ToInt32(input);

                    // Validate choice is within range
                    if (optionInt >= 1 && optionInt <= 6) // Updated validation range
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Error: Please select a valid option (1-5).");
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
        private static void DoDeposit(Bank bank)
        {
            Account? account = FindAccount(bank);
            if (account == null)
            {
                return;
            }

            Console.Write("Enter the amount to deposit: ");
            try
            {
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                DepositTransaction transaction = new DepositTransaction(account, amount);
                bank.ExecuteTransaction(transaction); // Use the bank's execute transaction
                transaction.Print();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch
            {
                Console.WriteLine("Error: Invalid numeric input for amount.");
            }
        }

        // Handles the withdrawal process by prompting for an amount and calling Account.Withdraw.
        private static void DoWithdraw(Bank bank)
        {
            Account? account = FindAccount(bank);
            if (account == null)
            {
                return;
            }

            Console.Write("Enter the amount to withdraw: ");
            try
            {
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                WithdrawTransaction transaction = new WithdrawTransaction(account, amount);
                bank.ExecuteTransaction(transaction); // Use the bank's execute transaction
                transaction.Print();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch
            {
                Console.WriteLine("Error: Invalid numeric input for amount.");
            }
        }

        // Handles the transfer process by prompting for amounts and accounts.
        private static void DoTransfer(Bank bank)
        {
            Console.WriteLine("--- Transfer From ---");
            Account? fromAccount = FindAccount(bank);
            if (fromAccount == null)
            {
                return;
            }

            Console.WriteLine("--- Transfer To ---");
            Account? toAccount = FindAccount(bank);
            if (toAccount == null)
            {
                return;
            }

            if (fromAccount == toAccount)
            {
                Console.WriteLine("Error: Cannot transfer money to the same account.");
                return;
            }

            Console.Write($"Enter the amount to transfer from {fromAccount.Name} to {toAccount.Name}: ");
            try
            {
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                TransferTransaction transaction = new TransferTransaction(fromAccount, toAccount, amount);
                bank.ExecuteTransaction(transaction); // Use the bank's execute transaction
                transaction.Print();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch
            {
                Console.WriteLine("Error: Invalid numeric input for amount.");
            }
        }

        private static void DoPrint(Bank bank)
        {
            if (bank.Accounts.Count == 0)
            {
                Console.WriteLine("No accounts in the bank to print.");
                return;
            }
            Console.WriteLine("\n--- All Bank Accounts ---");
            foreach (var account in bank.Accounts)
            {
                account.Print();
            }
            Console.WriteLine("-------------------------\n");
        }

        private static void DoAddAccount(Bank bank)
        {
            Console.Write("Enter the name for the new account: ");
            string? accountName = Console.ReadLine();

            Console.Write("Enter the initial balance for the new account: ");
            decimal initialBalance = 0;
            try
            {
                initialBalance = Convert.ToDecimal(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Error: Invalid numeric input for initial balance. Account not created.");
                return;
            }

            if (string.IsNullOrWhiteSpace(accountName))
            {
                Console.WriteLine("Error: Account name cannot be empty. Account not created.");
                return;
            }

            Account newAccount = new Account(accountName, initialBalance);
            bank.AddAccount(newAccount);
            Console.WriteLine($"Account '{accountName}' created with balance {initialBalance:C}.");
        }

        private static Account? FindAccount(Bank bank)
        {
            Console.Write("Enter account name: ");
            string? accountName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(accountName))
            {
                Console.WriteLine("Error: Account name cannot be empty.");
                return null;
            }

            Account? account = bank.GetAccount(accountName);

            if (account == null)
            {
                Console.WriteLine($"Error: Account '{accountName}' not found.");
            }
            return account;
        }
    }
}

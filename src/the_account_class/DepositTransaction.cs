using System;

namespace TheAccountClass
{
    public class DepositTransaction
    {
        private Account _account;
        private decimal _amount;
        private bool _executed;
        private bool _success;
        private bool _reversed;

        public DepositTransaction(Account account, decimal amount)
        {
            _account = account;
            _amount = amount;
            _executed = false;
            _success = false;
            _reversed = false;
        }

        public bool Executed
        {
            get { return _executed; }
        }

        public bool Success
        {
            get { return _success; }
        }

        public bool Reversed
        {
            get { return _reversed; }
        }

        public void Print()
        {
            Console.WriteLine("Deposit Transaction Details:");
            Console.WriteLine($"Account Name: {_account.Name}");
            Console.WriteLine($"Amount: {_amount:C}");
            Console.WriteLine($"Executed: {Executed}");
            Console.WriteLine($"Success: {Success}");
            Console.WriteLine($"Reversed: {Reversed}");

            if (Executed)
            {
                if (Success)
                {
                    Console.WriteLine("Status: Deposit successfully completed.");
                }
                else
                {
                    Console.WriteLine("Status: Deposit failed.");
                }
            }
            if (Reversed)
            {
                Console.WriteLine("Status: Transaction successfully reversed.");
            }
        }

        public void Execute()
        {
            if (_executed)
            {
                throw new InvalidOperationException("Transaction has already been attempted.");
            }
            if (_amount <= 0)
            {
                throw new InvalidOperationException("Deposit amount must be positive.");
            }

            _executed = true;
            if (_account.Deposit(_amount))
            {
                _success = true;
            }
            else
            {
                _success = false;
                // This else block might not be strictly necessary if Account.Deposit() always returns true for positive amounts,
                // but kept for consistency and potential future changes in Account.Deposit logic.
                throw new InvalidOperationException("Deposit failed for an unknown reason.");
            }
        }

        public void Rollback()
        {
            if (!_executed)
            {
                throw new InvalidOperationException("Transaction has not been executed yet.");
            }
            if (_reversed)
            {
                throw new InvalidOperationException("Transaction has already been reversed.");
            }
            if (!_success)
            {
                throw new InvalidOperationException("Cannot rollback a failed transaction.");
            }

            if (_account.Withdraw(_amount))
            {
                _reversed = true;
            }
            else
            {
                throw new InvalidOperationException("Failed to withdraw funds back from the account during rollback (insufficient funds?).");
            }
        }
    }
}

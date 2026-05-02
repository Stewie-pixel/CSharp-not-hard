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

        public bool Executed => _executed;   // Has the transaction been attempted?
        public bool Success => _success;    // Did the deposit succeed?
        public bool Reversed => _reversed;   // Has the transaction been rolled back?

        public void Print()
        {
            Console.WriteLine("Deposit Transaction Details:");
            Console.WriteLine($"Account Name: {_account.Name}");
            Console.WriteLine($"Amount: {_amount:C}");
            Console.WriteLine($"Executed: {Executed}");
            Console.WriteLine($"Success: {Success}");
            Console.WriteLine($"Reversed: {Reversed}");

            // Print human‑readable status
            if (Executed)
            {
                if (Success)
                    Console.WriteLine("Status: Deposit successfully completed.");
                else
                    Console.WriteLine("Status: Deposit failed.");
            }

            if (Reversed)
                Console.WriteLine("Status: Transaction successfully reversed.");
        }

        public void Execute()
        {
            // Prevent executing the same transaction twice
            if (_executed)
                throw new InvalidOperationException("Transaction has already been attempted.");

            // Validate deposit amount
            if (_amount <= 0)
                throw new InvalidOperationException("Deposit amount must be positive.");

            _executed = true;

            // Attempt the deposit on the account
            if (_account.Deposit(_amount))
            {
                _success = true;
            }
            else
            {
                _success = false;
                // Deposit should normally never fail if amount > 0
                throw new InvalidOperationException("Deposit failed for an unknown reason.");
            }
        }

        public void Rollback()
        {
            // Cannot rollback before execution
            if (!_executed)
                throw new InvalidOperationException("Transaction has not been executed yet.");

            // Cannot rollback twice
            if (_reversed)
                throw new InvalidOperationException("Transaction has already been reversed.");

            // Only successful transactions can be rolled back
            if (!_success)
                throw new InvalidOperationException("Cannot rollback a failed transaction.");

            // Reverse the deposit by withdrawing the same amount
            if (_account.Withdraw(_amount))
            {
                _reversed = true;
            }
            else
            {
                throw new InvalidOperationException(
                    "Failed to withdraw funds back from the account during rollback (insufficient funds?)."
                );
            }
        }
    }
}

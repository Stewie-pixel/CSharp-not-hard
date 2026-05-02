using System;

namespace TheAccountClass
{
    public class WithdrawTransaction
    {
        private Account _account;      // Account the money will be withdrawn from
        private decimal _amount;       // Amount to withdraw
        private bool _executed;        // True once Execute() has been called
        private bool _success;         // True if withdrawal succeeded
        private bool _reversed;        // True if rollback was performed

        public WithdrawTransaction(Account account, decimal amount)
        {
            _account = account;
            _amount = amount;
            _executed = false;
            _success = false;
            _reversed = false;
        }

        public bool Executed => _executed;   // Has the transaction been attempted?
        public bool Success => _success;    // Did the withdrawal succeed?
        public bool Reversed => _reversed;   // Has the transaction been rolled back?

        public void Print()
        {
            Console.WriteLine("Withdrawal Transaction Details:");
            Console.WriteLine($"Account Name: {_account.Name}");
            Console.WriteLine($"Amount: {_amount:C}");
            Console.WriteLine($"Executed: {Executed}");
            Console.WriteLine($"Success: {Success}");
            Console.WriteLine($"Reversed: {Reversed}");

            // Human‑readable status messages
            if (Executed)
            {
                if (Success)
                    Console.WriteLine("Status: Withdrawal successfully completed.");
                else
                    Console.WriteLine("Status: Withdrawal failed.");
            }

            if (Reversed)
                Console.WriteLine("Status: Transaction successfully reversed.");
        }

        public void Execute()
        {
            // Prevent executing the same transaction twice
            if (_executed)
                throw new InvalidOperationException("Transaction has already been attempted.");

            _executed = true;

            // Attempt the withdrawal on the account
            if (_account.Withdraw(_amount))
            {
                _success = true;
            }
            else
            {
                _success = false;
                // Withdrawal fails if insufficient funds or invalid amount
                throw new InvalidOperationException("Insufficient funds or invalid amount for withdrawal.");
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

            // Only successful withdrawals can be rolled back
            if (!_success)
                throw new InvalidOperationException("Cannot rollback a failed transaction.");

            // Reverse the withdrawal by depositing the same amount
            if (_account.Deposit(_amount))
            {
                _reversed = true;
            }
            else
            {
                throw new InvalidOperationException(
                    "Failed to deposit funds back to the account during rollback."
                );
            }
        }
    }
}

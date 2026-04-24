using System;

namespace TheAccountClass
{
    public class WithdrawTransaction
    {
        private Account _account;
        private decimal _amount;
        private bool _executed;
        private bool _success;
        private bool _reversed;

        public WithdrawTransaction(Account account, decimal amount)
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
            Console.WriteLine("Withdrawal Transaction Details:");
            Console.WriteLine($"Account Name: {_account.Name}");
            Console.WriteLine($"Amount: {_amount:C}");
            Console.WriteLine($"Executed: {Executed}");
            Console.WriteLine($"Success: {Success}");
            Console.WriteLine($"Reversed: {Reversed}");

            if (Executed)
            {
                if (Success)
                {
                    Console.WriteLine("Status: Withdrawal successfully completed.");
                }
                else
                {
                    Console.WriteLine("Status: Withdrawal failed.");
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

            _executed = true;
            if (_account.Withdraw(_amount))
            {
                _success = true;
            }
            else
            {
                _success = false;
                throw new InvalidOperationException("Insufficient funds or invalid amount for withdrawal.");
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

            if (_account.Deposit(_amount))
            {
                _reversed = true;
            }
            else
            {
                throw new InvalidOperationException("Failed to deposit funds back to the account during rollback.");
            }
        }
    }
}

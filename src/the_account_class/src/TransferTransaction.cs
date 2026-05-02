using System;

namespace TheAccountClass
{
    public class TransferTransaction
    {
        private Account _fromAccount;
        private Account _toAccount;
        private decimal _amount;
        private DepositTransaction _deposit;
        private WithdrawTransaction _withdraw;
        private bool _executed;
        private bool _reversed;

        public TransferTransaction(Account fromAccount, Account toAccount, decimal amount)
        {
            _fromAccount = fromAccount;
            _toAccount = toAccount;
            _amount = amount;
            _withdraw = new WithdrawTransaction(fromAccount, amount);
            _deposit = new DepositTransaction(toAccount, amount);
            _executed = false;
            _reversed = false;
        }

        public bool Executed
        {
            get { return _executed; }
        }

        public bool Success
        {
            // Success is true only if both withdraw and deposit transactions succeeded
            get { return _withdraw.Success && _deposit.Success; }
        }

        public bool Reversed
        {
            get { return _reversed; }
        }

        public void Print()
        {
            Console.WriteLine("Transfer Transaction Details:");
            Console.WriteLine($"From Account: {_fromAccount.Name}");
            Console.WriteLine($"To Account: {_toAccount.Name}");
            Console.WriteLine($"Amount: {_amount:C}");
            Console.WriteLine($"Executed: {Executed}");
            Console.WriteLine($"Success: {Success}");
            Console.WriteLine($"Reversed: {Reversed}");

            if (Executed)
            {
                if (Success)
                {
                    Console.WriteLine("Status: Transfer successfully completed.");
                }
                else
                {
                    Console.WriteLine("Status: Transfer failed.");
                }
            }
            if (Reversed)
            {
                Console.WriteLine("Status: Transaction successfully reversed.");
            }

            Console.WriteLine(""); // Add an empty line for spacing
            Console.WriteLine("Withdrawal Leg Details:");
            _withdraw.Print();
            Console.WriteLine(""); // Add an empty line for spacing
            Console.WriteLine("Deposit Leg Details:");
            _deposit.Print();
        }

        public void Execute()
        {
            if (_executed)
            {
                throw new InvalidOperationException("Transfer transaction has already been attempted.");
            }

            _executed = true;

            try
            {
                _withdraw.Execute();
                _deposit.Execute();
            }
            catch (InvalidOperationException ex)
            {
                // If either withdraw or deposit fails, the transfer fails.
                // Re-throw the exception after attempting to rollback the withdraw if it succeeded partially.
                if (_withdraw.Success)
                {
                    try
                    {
                        _withdraw.Rollback();
                    }
                    catch (InvalidOperationException rollbackEx)
                    {
                        Console.WriteLine($"Warning: Failed to rollback partial withdrawal during transfer failure: {rollbackEx.Message}");
                    }
                }
                throw new InvalidOperationException($"Transfer failed: {ex.Message}", ex);
            }
        }

        public void Rollback()
        {
            if (!_executed)
            {
                throw new InvalidOperationException("Transfer transaction has not been executed yet.");
            }
            if (_reversed)
            {
                throw new InvalidOperationException("Transfer transaction has already been reversed.");
            }
            if (!Success)
            {
                throw new InvalidOperationException("Cannot rollback a failed transfer transaction.");
            }

            try
            {
                _deposit.Rollback();
                _withdraw.Rollback();
                _reversed = true;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Rollback of transfer failed: {ex.Message}", ex);
            }
        }
    }
}

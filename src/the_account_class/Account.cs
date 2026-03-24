using System;

namespace TheAccountClass
{
    public class Account
    {
        private decimal _balance;
        private string _name;

        public Account(string name, decimal balance)
        {
            _name = name;
            _balance = balance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be positive.");
            }
            
            _balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be positive.");
            }
            
            if (amount > _balance)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }
            
            _balance -= amount;
        }

        public void Print()
        {
            Console.WriteLine("Account Name: " + _name);
            Console.WriteLine("Balance: " + _balance.ToString("C"));
        }

        public string Name
        {
            get { return _name; }
        }
    }
}

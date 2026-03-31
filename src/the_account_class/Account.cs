using System;

namespace TheAccountClass
{
   
    public class Account
    {
        private decimal _balance;
        private string _name;

        // Initializes a new instance of the Account class.
        public Account(string name, decimal balance)
        {
            _name = name;
            _balance = balance;
        }

        // Deposits a specified amount into the account if the amount is positive.
        // return true if the deposit was successful otherwise false.
        public bool Deposit(decimal amount)
        {
            if (amount > 0)
            {
                _balance += amount;
                return true;
            }
            // Deposit fails if amount is 0 or negative
            return false;
        }

        // Withdraws a specified amount from the account if the amount is positive and does not exceed the balance.
        // returns True if the withdrawal was successful otherwise false.
        public bool Withdraw(decimal amount)
        {
            // Ensure amount is positive and the account has enough funds
            if (amount > 0 && amount <= _balance)
            {
                _balance -= amount;
                return true;
            }
            // Withdrawal fails if amount is invalid or funds are insufficient
            return false;
        }

        // Prints the account name and current balance to the console.
        public void Print()
        {
            Console.WriteLine("Account Name: " + _name);
            Console.WriteLine("Balance: " + _balance.ToString("C"));
        }

        // Gets the name of the account holder.
        public string Name
        {
            get { return _name; }
        }
    }
}

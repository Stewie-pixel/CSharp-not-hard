using System;
using System.Collections.Generic;

namespace TheAccountClass
{
    public class Bank
    {
        private List<Account> _accounts;   // Stores all accounts managed by the bank

        public Bank()
        {
            _accounts = new List<Account>();   // Initialise empty account list
        }

        public List<Account> Accounts
        {
            get { return _accounts; }          // Expose accounts as read‑only property
        }

        public void AddAccount(Account account)
        {
            _accounts.Add(account);            // Add a new account to the bank
        }

        public Account GetAccount(string name)
        {
            // Find an account by its name (returns null if not found)
            foreach (var account in _accounts)
            {
                if (account.Name == name)
                {
                    return account;
                }
            }
            return null;
        }

        // Execute a deposit transaction
        public void ExecuteTransaction(DepositTransaction transaction)
        {
            transaction.Execute();
        }

        // Execute a withdrawal transaction
        public void ExecuteTransaction(WithdrawTransaction transaction)
        {
            transaction.Execute();
        }

        // Execute a transfer transaction
        public void ExecuteTransaction(TransferTransaction transaction)
        {
            transaction.Execute();
        }
    }
}

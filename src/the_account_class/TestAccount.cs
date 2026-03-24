using System;

namespace TheAccountClass
{
    public class TestAccount
    {
        public static void Main(string[] args)
        {
            // Create a new account
            Account myAccount = new Account("Jake's Account", 200000.00m);

            // Test Print
            myAccount.Print();

            // Test Deposit
            try
            {
                myAccount.Deposit(100.00m);
                myAccount.Print();
                
                // Test invalid deposit
                myAccount.Deposit(-50.00m);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during deposit: " + ex.Message);
            }

            // Test Withdraw
            try
            {
                myAccount.Withdraw(50.00m);
                myAccount.Print();
                
                // Test withdraw more than balance (Withdraw before deposit scenario if balance was 0, or just insufficient funds)
                myAccount.Withdraw(1000000.00m);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during withdrawal: " + ex.Message);
            }

            // Test Name property
            Console.WriteLine("Account Name via Property: " + myAccount.Name);


        }
    }
}

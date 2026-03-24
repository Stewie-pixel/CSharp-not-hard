using System;

namespace Task1_Mobile
{
    public class Mobile
    {
        // Instance Variables
        private string accType;
        private string device;
        private string number;
        private double balance;

        // Constants
        private const double CALL_COST = 0.245;
        private const double TEXT_COST = 0.078;

        // Constructor
        public Mobile(string accType, string device, string number)
        {
            this.accType = accType;
            this.device = device;
            this.number = number;
            this.balance = 0.0;
        }

        // Accessor Methods
        public string getAccType()
        {
            return this.accType;
        }

        public string getDevice()
        {
            return this.device;
        }

        public string getNumber()
        {
            return this.number;
        }

        public string getBalance()
        {
            return this.balance.ToString("C");
        }

        // Mutator Methods
        public void setAccType(string accType)
        {
            this.accType = accType;
        }

        public void setDevice(string device)
        {
            this.device = device;
        }

        public void setNumber(string number)
        {
            this.number = number;
        }

        public void setBalance(double balance)
        {
            this.balance = balance;
        }

        // Operational Methods
        public void addCredit(double amount)
        {
            this.balance += amount;
            Console.WriteLine("Credit added successfully. New balance " + getBalance());
        }

        public void makeCall(int minutes)
        {
            double cost = minutes * CALL_COST;
            this.balance -= cost;
            Console.WriteLine("Call made. New balance " + getBalance());
        }

        public void sendText(int numTexts)
        {
            double cost = numTexts * TEXT_COST;
            this.balance -= cost;
            Console.WriteLine("Text Sent. New balance " + getBalance());
        }
    }
}

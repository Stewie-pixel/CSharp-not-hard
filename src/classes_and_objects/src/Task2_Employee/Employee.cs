using System;

namespace Task2_Employee
{
    public class Employee
    {
        private string name;
        private double salary;

        public Employee(string name, double currentSalary)
        {
            this.name = name;
            this.salary = currentSalary;
        }

        public string getName()
        {
            return this.name;
        }

        public string getSalary()
        {
            return this.salary.ToString("C");
        }

        public void raiseSalary(double percentage)
        {
            this.salary += this.salary * (percentage / 100);
        }

        public double Tax()
        {
            double tax = 0.0;
            if (salary <= 18200)
            {
                tax = 0;
            }
            else if (salary <= 37000)
            {
                tax = (salary - 18200) * 0.19;
            }
            else if (salary <= 90000)
            {
                tax = 3572 + (salary - 37000) * 0.325;
            }
            else if (salary <= 180000)
            {
                tax = 20797 + (salary - 90000) * 0.37;
            }
            else
            {
                tax = 54096 + (salary - 180000) * 0.45;
            }
            return tax;
        }
    }
}

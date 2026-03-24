using System;

namespace Task2_Employee
{
    class EmployeeProgram
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee("John Doe", 50000);

            Console.WriteLine("Employee Name: " + emp.getName());
            Console.WriteLine("Current Salary: " + emp.getSalary());
            Console.WriteLine("Calculated Tax: " + emp.Tax().ToString("C"));

            Console.WriteLine("\nRaising salary by 10%...");
            emp.raiseSalary(10);

            Console.WriteLine("New Salary: " + emp.getSalary());
            Console.WriteLine("New Tax: " + emp.Tax().ToString("C"));

            // Test case for another tax bracket
            Employee emp2 = new Employee("Jane Smith", 200000);
            Console.WriteLine("\nEmployee Name: " + emp2.getName());
            Console.WriteLine("Current Salary: " + emp2.getSalary());
            Console.WriteLine("Calculated Tax: " + emp2.Tax().ToString("C"));

            Console.ReadLine();
        }
    }
}

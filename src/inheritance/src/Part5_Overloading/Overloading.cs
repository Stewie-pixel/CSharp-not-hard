using System;

namespace Part5_Overloading
{
    internal class Overloading
    {
        // This method displays a name.
        public static void methodToBeOverloaded (String name)
        {
            Console.WriteLine("Name: " + name);
        }

        // This method displays a name and an age.
        public static void methodToBeOverloaded (String name, int age)
        {
            Console.WriteLine("Name: " + name + " Age: " + age);
        }

        // This is the main entry point of the program, demonstrating method overloading.
        static void Main(string[] args)
        {
            Console.WriteLine("Method Overloading Example: ");
            methodToBeOverloaded("John");
            methodToBeOverloaded("Jane", 30);
        }
    }
}
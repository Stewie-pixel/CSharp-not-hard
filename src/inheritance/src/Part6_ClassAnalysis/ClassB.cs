using System;

namespace Part6_ClassAnalysis
{
    public class ClassB : ClassA
    {
        // This method overrides the base class's Division method to perform division with an integer.
        public override double Division(int j)
        {
            return (double)i / j;
        }

        // This method prints the results of arithmetic operations using the class's current values and a provided integer.
        public void PrintResults (int j)
        {
            Console.WriteLine("i: {0}", base.i);
            Console.WriteLine("Sum(j): {0}", Sum(j));
            Console.WriteLine("Product(j): {0}", Product(j));
            Console.WriteLine("Division(j): {0}", Division(j));
        }
    }
}
using System;

namespace Part6_ClassAnalysis
{
    public class ClassA
    {
        // This field stores an integer value.
        protected int i = 10;

        // This method calculates the sum of the internal integer and the provided integer.
        public int Sum(int j)
        {
            return i + j;
        }

        // This method calculates the product of the internal integer and the provided integer.
        public int Product (int j)
        {
            return i * j;
        }

        // This virtual method calculates the division of the internal integer by the provided integer.
        public virtual double Division (int j)
        {
            return i / j;
        }
    }
}
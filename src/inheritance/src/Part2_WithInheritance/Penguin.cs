using System;

namespace Part2_WithInheritance
{
    class Penguin : Bird
    {
        // This constructor initializes a new instance of the Penguin class with specified attributes, inheriting from Bird.
        public Penguin(String name, String diet, String location,
                       double weight, int age, String colour, double wingSpan)
            : base(name, diet, location, weight, age, colour, wingSpan)
        {
            // No unique attributes for Penguin at this stage
        }

        // This method overrides the base fly method to describe how a penguin moves.
        public override void fly()
        {
            Console.WriteLine("A penguin cannot fly, but it can swim very well!");
        }
    }
}
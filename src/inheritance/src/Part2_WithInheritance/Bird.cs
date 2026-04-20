using System;

namespace Part2_WithInheritance
{
    class Bird : AnimalWithInheritance
    {
        // This field stores the wing span of the bird.
        private double wingSpan;

        // This constructor initializes a new instance of the Bird class with specified attributes, inheriting from AnimalWithInheritance.
        public Bird(String name, String diet, String location,
                    double weight, int age, String colour, double wingSpan)
            : base(name, diet, location, weight, age, colour)
        {
            this.wingSpan = wingSpan;
        }

        // This method simulates a bird flying.
        public virtual void fly()
        {
            Console.WriteLine("A bird flies.");
        }
    }
}
using System;

namespace Part2_WithInheritance
{
    class Wolf : AnimalWithInheritance
    {
        // This constructor initializes a new instance of the Wolf class with specified attributes, inheriting from AnimalWithInheritance.
        public Wolf(String name, String diet, String location,
                    double weight, int age, String colour)
            : base(name, diet, location, weight, age, colour)
        {
            // No unique attributes for Wolf at this stage
        }

        // This method simulates the wolf howling.
        public override void makeNoise()
        {
            Console.WriteLine("Awooooo!"); // Wolf howls
        }

        // This method describes the wolf's eating habits, specifically eating a certain amount of meat.
        public override void eat()
        {
            Console.WriteLine("I can eat 10lbs of meat");
        }

        // This method describes the wolf's cooperative hunting behavior.
        public override void Hunt()
        {
            Console.WriteLine("Wolf pack hunts cooperatively.");
        }
    }
}
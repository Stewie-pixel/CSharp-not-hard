using System;

namespace Part2_WithInheritance
{
    class Feline : AnimalWithInheritance
    {
        // This field stores the species of the feline.
        private String species;

        // This constructor initializes a new instance of the Feline class with specified attributes, inheriting from AnimalWithInheritance.
        public Feline(String name, String diet, String location,
                      double weight, int age, String colour, String species)
            : base(name, diet, location, weight, age, colour)
        {
            this.species = species;
        }

        // This method simulates the feline sleeping.
        public new void sleep()
        {
            Console.WriteLine("Feline is sleeping.");
        }
    }
}
using System;

namespace Part2_WithInheritance
{
    class Lion : Feline
    {
        // This constructor initializes a new instance of the Lion class with specified attributes, inheriting from Feline.
        public Lion(String name, String diet, String location,
                    double weight, int age, String colour, String species)
            : base(name, diet, location, weight, age, colour, species)
        {
            // No unique attributes for Lion at this stage
        }
    }
}
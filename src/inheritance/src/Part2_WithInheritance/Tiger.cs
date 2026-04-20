using System;

namespace Part2_WithInheritance
{
    class Tiger : Feline
    {
        // This field stores the color of the tiger's stripes.
        private String colourStripes;

        // This constructor initializes a new instance of the Tiger class with specified attributes, inheriting from Feline.
        public Tiger(String name, String diet, String location,
                     double weight, int age, String colour, String species, String colourStripes)
            : base(name, diet, location, weight, age, colour, species)
        {
            this.colourStripes = colourStripes;
        }

        // This method simulates the tiger making a loud roaring noise.
        public override void makeNoise()
        {
            Console.WriteLine("ROARRRRRRRRR");
        }

        // This method describes the tiger's eating habits, specifically eating a large amount of meat.
        public override void eat()
        {
            Console.WriteLine("I can eat 20lbs of meat");
        }

        // This method describes the tiger's hunting strategy.
        public override void Hunt()
        {
            Console.WriteLine("Tiger stalks and ambushes prey.");
        }
    }
}
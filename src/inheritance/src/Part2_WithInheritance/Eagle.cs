using System;

namespace Part2_WithInheritance
{
    class Eagle : Bird
    {
        // This constructor initializes a new instance of the Eagle class with specified attributes, inheriting from Bird.
        public Eagle(String name, String diet, String location,
                     double weight, int age, String colour, double wingSpan)
            : base(name, diet, location, weight, age, colour, wingSpan)
        {
            // Species attribute was removed previously, now wingSpan is inherited from Bird.
        }

        // This method allows the eagle to lay eggs.
        public void layEgg()
        {
            // Code to allow eagles to lay eggs
        }

        // This method simulates an eagle flying high.
        public override void fly()
        {
            Console.WriteLine("An eagle flies high!");
        }

        // This method simulates the eagle's cry.
        public override void makeNoise()
        {
            Console.WriteLine("Screeech!"); // Eagle cry
        }

        // This method specifies the eagle's eating behavior, specifically eating fish.
        public override void eat()
        {
            Console.WriteLine("I can eat 1 ton of fish");
        }

        // This method describes the eagle's hunting behavior.
        public override void Hunt()
        {
            Console.WriteLine("Eagle hunts for prey.");
        }
    }
}
using System;

namespace Part2_WithInheritance
{
    class AnimalWithInheritance
    {
        // This field stores the name of the animal.
        private String name;
        // This field stores the diet of the animal.
        private String diet;
        // This field stores the location of the animal.
        private String location;
        // This field stores the weight of the animal.
        private double weight;
        // This field stores the age of the animal.
        private int age;
        // This field stores the colour of the animal.
        private String colour;

        // This constructor initializes a new instance of the AnimalWithInheritance class with specified attributes.
        public AnimalWithInheritance(String name, String diet, String location,
                                     double weight, int age, String colour)
        {
            this.name = name;
            this.diet = diet;
            this.location = location;
            this.weight = weight;
            this.age = age;
            this.colour = colour;
        }

        // This method provides a string representation of the AnimalWithInheritance object.
        public override string ToString()
        {
            return $"Name: {name}, Diet: {diet}, Location: {location}, Weight: {weight}kg, Age: {age}, Colour: {colour}";
        }

        // This method simulates the animal eating.
        public virtual void eat()
        {
            Console.WriteLine("An animal eats");
        }

        // This method simulates the animal sleeping.
        public void sleep()
        {
            // Code for the animal to sleep
        }

        // This method simulates the animal making a noise.
        public virtual void makeNoise()
        {
            Console.WriteLine("An animal makes a noise");
        }

        // This method simulates the animal hunting for food.
        public virtual void Hunt()
        {
            Console.WriteLine("An animal hunts for food.");
        }
    }
}
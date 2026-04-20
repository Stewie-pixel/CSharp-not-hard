using System;

namespace Part1_NoInheritance
{
    class Animal
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

        // This constructor initializes a new instance of the Animal class with specified attributes.
        public Animal(String name, String diet, String location,
                      double weight, int age, String colour)
        {
            this.name = name;
            this.diet = diet;
            this.location = location;
            this.weight = weight;
            this.age = age;
            this.colour = colour;
        }

        // This method provides a string representation of the Animal object.
        public override string ToString()
        {
            return $"Name: {name}, Diet: {diet}, Location: {location}, Weight: {weight}kg, Age: {age}, Colour: {colour}";
        }

        // This method simulates the animal eating.
        public void eat()
        {
            //Code for the animal to eat
        }

        // This method simulates the animal sleeping.
        public void sleep()
        {
            //Code for the animal to sleep
        }

        // This method simulates the animal making a general noise.
        public void makeNoise()
        {
            //Code for the animal to make a noise
        }

        // This method simulates a lion roaring.
        public void makeLionNoise()
        {
            //Code for the lions to roar
        }

        // This method simulates the animal eating meat.
        public void eatMeat()
        {
            //Code for the animal to eat meat
        }

        // This method simulates an eagle crying.
        public void makeEagleNoise()
        {
            //Code for the eagles to cry
        }

        // This method simulates the animal eating berries.
        public void eatBerries()
        {
            //Code for the animal to eat berries
        }

        // This method simulates a wolf howling.
        public void makeWolfNoise()
        {
            //Code for the wolves to howl
        }


    }
}
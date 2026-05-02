using System;
using System.Collections.Generic;
using System.Linq; // Added for any potential LINQ operations for IEnumerable

class Program
{
    static void Main(string[] args)
    {

        // Step 2: Test Each Class
        Console.WriteLine("\nStep 2: Testing Individual Classes");
        // Create two Bird objects, set names, print ToString() and call fly().
        Bird bird1 = new Bird("Sparrow");
        Bird bird2 = new Bird("Eagle");
        Console.WriteLine(bird1.ToString());
        bird1.fly();
        Console.WriteLine(bird2.ToString());
        bird2.fly();

        // Create two Penguin objects, set names, print and call fly().
        Penguin penguin1 = new Penguin("Skipper");
        Penguin penguin2 = new Penguin("Kowalski");
        Console.WriteLine(penguin1.ToString());
        penguin1.fly();
        Console.WriteLine(penguin2.ToString());
        penguin2.fly();

        // Create two Duck objects, set name/size/kind, print and call fly().
        Duck duck1 = new Duck("Daffy", 12.5, "Mallard");
        Duck duck2 = new Duck("Donald", 10.0, "Pekin");
        Console.WriteLine(duck1.ToString());
        duck1.fly();
        Console.WriteLine(duck2.ToString());
        duck2.fly();

        // Step 3: Use Polymorphism with a List<Bird>
        Console.WriteLine("\nStep 3: Polymorphism with List<Bird>");
        List<Bird> birds = new List<Bird>();
        birds.Add(new Bird("Robin"));
        birds.Add(new Penguin("Private"));
        birds.Add(new Duck("Huey", 9.0, "Wood Duck"));

        foreach (Bird bird in birds)
        {
            Console.WriteLine(bird); // Calls the overridden ToString()
            bird.fly();             // Calls the overridden fly()
        }

        // Step 4: Demonstrate Covariance with IEnumerable<T>
        Console.WriteLine("\nStep 4: Covariance with IEnumerable<T>");
        List<Duck> ducksToAdd = new List<Duck>
        {
            new Duck("Louie", 8.5, "Teal"),
            new Duck("Dewey", 11.0, "Canvasback")
        };

        // Assign List<Duck> to IEnumerable<Bird> - Covariance
        IEnumerable<Bird> upcastDucks = ducksToAdd;

        List<Bird> allBirds = new List<Bird>();
        allBirds.Add(new Bird("Pigeon"));

        // Add the duck collection using AddRange
        allBirds.AddRange(upcastDucks);

        Console.WriteLine("All birds in the combined list:");
        foreach (Bird bird in allBirds)
        {
            Console.WriteLine(bird);
            bird.fly();
        }
    }
}
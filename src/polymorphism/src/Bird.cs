using System;

// A. Bird (base class)
public class Bird
{
    // Name property for the bird
    public string Name { get; set; }

    // Initializes a new instance of the Bird class.
    // The name of the bird
    public Bird(string name)
    {
        Name = name;
    }

    // Represents the flying action of a bird.
    // This method is virtual, allowing derived classes to override it.
    public virtual void fly()
    {
        Console.WriteLine("Flap, Flap, Flap");
    }

    // Returns a string representation of the Bird object.
    // A string in the format "A bird called <name>"
    public override string ToString()
    {
        return $"A bird called {Name}";
    }
}

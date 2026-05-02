using System;

// B. Penguin : Bird
public class Penguin : Bird
{

    // Initializes a new instance of the Penguin class.
    public Penguin(string name) : base(name)
    {
    }

    // Overrides the fly method to indicate that penguins cannot fly.
    public override void fly()
    {
        Console.WriteLine("Penguins cannot fly");
    }

    // Returns a string representation of the Penguin object.
    public override string ToString()
    {
        return $"A penguin named {Name}";
    }
}

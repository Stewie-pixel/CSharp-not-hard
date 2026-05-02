using System;

// C. Duck : Bird
public class Duck : Bird
{
    // Size property for the duck
    public double Size { get; set; }
    // Kind property for the duck
    public string Kind { get; set; }

    // Initializes a new instance of the Duck class.
    // The name of the duck.
    // The size of the duck in inches.
    // The kind or breed of the duck
    public Duck(string name, double size, string kind) : base(name)
    {
        Size = size;
        Kind = kind;
    }

    // Returns a string representation of the Duck object.
    // A string in the format "A duck named <name> is a <size> inch <kind>"
    public override string ToString()
    {
        return $"A duck named {Name} is a {Size} inch {Kind}";
    }
    // No override for fly() in Duck, so it inherits the Bird's "Flap, Flap, Flap" behavior.
}

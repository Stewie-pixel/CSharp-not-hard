using System;

namespace Part1_NoInheritance
{
    internal class ZooPark
    {
        // This is the main entry point of the program.
        static void Main(string[] args)
        {
            Animal williamWolf = new Animal ("William the Wolf", "Meat", "Dog Village", 50.6, 9, "Grey");
            Animal tonyTiger = new Animal ("Tony the Tiger", "Meat", "Cat Land", 110, 6, "Orange and White");
            Animal edgarEagle = new Animal ("Edgar the Eagle", "Fish", "Bird Mania", 20, 15, "Black");

            Console.WriteLine("Animal Details:");
            Console.WriteLine(williamWolf.ToString());
            Console.WriteLine(tonyTiger.ToString());
            Console.WriteLine(edgarEagle.ToString());
        }
    }
}
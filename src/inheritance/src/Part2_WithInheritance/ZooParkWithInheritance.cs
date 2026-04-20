using System;

namespace Part2_WithInheritance
{
    internal class ZooParkWithInheritance
    {
        // This is the main entry point of the program, demonstrating polymorphism and inheritance with various animal objects.
        static void Main(string[] args)
        {
            AnimalWithInheritance williamWolf = new Wolf("William the Wolf", "Meat", "Dog Village",
                                                    50.6, 9, "Grey");
            // Animal tonyTiger = new AnimalWithInheritance ("Tony the Tiger", "Meat", "Cat Land", 110, 6, "Orange and White"); // Commented out as per instructions
            // AnimalWithInheritance edgarEagle = new Eagle("Edgar the Eagle", "Fish", "Bird Mania",
            //                                         20, 15, "Black", "Harpy", 98.5); // Old Eagle creation

            Tiger tonyTiger = new Tiger("Tony the Tiger", "Meat", "Cat Land",
                                        110, 6, "Orange and White", "Siberian", "White");

            AnimalWithInheritance baseAnimal = new AnimalWithInheritance ("Animal Name", "Animal Diet", "Animal Location", 0.0, 0, "Animal Colour");

            Lion simbaLion = new Lion("Simba the Lion", "Meat", "Lion's Den", 190.5, 8, "Golden", "African Lion");
            Penguin chillyPenguin = new Penguin("Chilly the Penguin", "Fish", "Icy Waters", 35.0, 5, "Black and White", 0.5);
            Eagle edgarEagle = new Eagle("Edgar the Eagle", "Fish", "Mountain Peak", 20, 15, "Brown", 2.2);

            Console.WriteLine("\n--- Animal Actions ---");
            baseAnimal.makeNoise();
            tonyTiger.makeNoise();
            williamWolf.makeNoise();
            edgarEagle.makeNoise();
            simbaLion.makeNoise();
            chillyPenguin.makeNoise();

            tonyTiger.eat();
            baseAnimal.eat();
            williamWolf.eat();
            edgarEagle.eat();
            simbaLion.eat();
            chillyPenguin.eat();

            baseAnimal.sleep();
            tonyTiger.sleep();
            williamWolf.sleep();
            edgarEagle.sleep();
            simbaLion.sleep();
            chillyPenguin.sleep();

            edgarEagle.fly();
            chillyPenguin.fly();

            tonyTiger.Hunt();
            williamWolf.Hunt();
            edgarEagle.Hunt();
            simbaLion.Hunt();
            chillyPenguin.Hunt();

            Console.WriteLine("\n--- Animal Details ---");
            Console.WriteLine(williamWolf.ToString());
            Console.WriteLine(tonyTiger.ToString());
            Console.WriteLine(edgarEagle.ToString());
            Console.WriteLine(simbaLion.ToString());
            Console.WriteLine(chillyPenguin.ToString());
        }
    }
}
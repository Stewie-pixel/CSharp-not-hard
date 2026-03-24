using System;

namespace Task3_Car
{
    class CarProgram
    {
        static void Main(string[] args)
        {
            Car myCar = new Car(30.0); // 30 mpg

            Console.WriteLine("Initial Fuel: " + myCar.getFuel() + " litres");
            Console.WriteLine("Total Miles: " + myCar.getTotalMiles());

            Console.WriteLine("\nAdding 10 gallons of fuel...");
            myCar.addFuel(10.0); // Adds ~45.46 litres

            Console.WriteLine("Fuel in Tank: " + myCar.getFuel().ToString("F2") + " litres");

            Console.WriteLine("\nDriving 150 miles...");
            myCar.drive(150.0); // Should use 5 gallons (~22.73 litres)

            Console.WriteLine("Fuel left: " + myCar.getFuel().ToString("F2") + " litres");
            Console.WriteLine("Total Miles: " + myCar.getTotalMiles());

            Console.WriteLine("\nCost per litre is: " + myCar.printFuelCost());

            Console.ReadLine();
        }
    }
}

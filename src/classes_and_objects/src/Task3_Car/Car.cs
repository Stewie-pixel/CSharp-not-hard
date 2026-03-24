using System;

namespace Task3_Car
{
    public class Car
    {
        private double fuelEfficiency; // in mpg
        private double fuelInTank; // in litres
        private double totalMilesDriven; // in miles

        private const double COST_PER_LITRE = 1.385;

        public Car(double mpg)
        {
            this.fuelEfficiency = mpg;
            this.fuelInTank = 0;
            this.totalMilesDriven = 0;
        }

        public double getFuel()
        {
            return this.fuelInTank;
        }

        public double getTotalMiles()
        {
            return this.totalMilesDriven;
        }

        public void setTotalMiles(double miles)
        {
            this.totalMilesDriven = miles;
        }

        public string printFuelCost()
        {
            return COST_PER_LITRE.ToString("C");
        }

        public double convertToLitres(double gallons)
        {
            return gallons * 4.546;
        }

        public double calcCost(double litres)
        {
            return litres * COST_PER_LITRE;
        }

        public void addFuel(double gallons)
        {
#if DEBUG
            System.Diagnostics.Debugger.Break(); // Programmatic breakpoint for demonstration
#endif
            double litres = convertToLitres(gallons);
            this.fuelInTank += litres;
            double cost = calcCost(litres);
            Console.WriteLine("Added " + litres.ToString("F2") + " litres. Cost: " + cost.ToString("C"));
        }

        public void drive(double miles)
        {
#if DEBUG
            System.Diagnostics.Debugger.Break(); // Programmatic breakpoint for demonstration
#endif
            double gallonsUsed = miles / this.fuelEfficiency;
            double litresUsed = convertToLitres(gallonsUsed);
            
            this.fuelInTank -= litresUsed;
            this.totalMilesDriven += miles;
            
            double cost = calcCost(litresUsed);
            
            Console.WriteLine("Drove " + miles + " miles. Fuel used: " + litresUsed.ToString("F2") + " litres. Cost: " + cost.ToString("C"));
        }
    }
}

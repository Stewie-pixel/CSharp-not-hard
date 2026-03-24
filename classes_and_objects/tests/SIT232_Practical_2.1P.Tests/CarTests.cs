using Xunit;
using Task3_Car;

namespace SIT232_Practical_2._1P.Tests
{
    public class CarTests
    {
        [Fact]
        public void Car_Initialization_ShouldStartEmpty()
        {
            Car car = new Car(30.0); // 30 mpg
            Assert.Equal(0, car.getFuel());
            Assert.Equal(0, car.getTotalMiles());
        }

        [Fact]
        public void Car_AddFuel_ShouldIncreaseFuelInLitres()
        {
            Car car = new Car(30.0);
            // 1 gallon = 4.546 litres
            car.addFuel(10.0); 

            Assert.Equal(45.46, car.getFuel(), 2);
        }

        [Fact]
        public void Car_Drive_ShouldReduceFuelAndIncreaseMiles()
        {
            Car car = new Car(30.0); // 30 mpg
            car.addFuel(10.0); // 45.46 litres
            
            // Drive 150 miles.
            // Gallons needed = 150 / 30 = 5 gallons.
            // Litres needed = 5 * 4.546 = 22.73 litres.
            car.drive(150.0);

            Assert.Equal(150.0, car.getTotalMiles());
            // Remaining fuel = 45.46 - 22.73 = 22.73
            Assert.Equal(22.73, car.getFuel(), 2);
        }

        [Fact]
        public void Car_CalcCost_ShouldBeAccurate()
        {
            Car car = new Car(30.0);
            // Testing public helper method if available, or effect of addFuel cost print?
            // Since calcCost is public in my implementation:
            double litres = 10.0;
            double expectedCost = 10.0 * 1.385; // 13.85
            
            Assert.Equal(expectedCost, car.calcCost(litres), 2);
        }
    }
}

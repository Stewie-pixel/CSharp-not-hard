using Xunit;
using Task2_Employee;

namespace SIT232_Practical_2._1P.Tests
{
    public class EmployeeTests
    {
        [Fact]
        public void Employee_Initialization_ShouldSetValues()
        {
            Employee emp = new Employee("Alice", 50000);
            Assert.Equal("Alice", emp.getName());
            Assert.Contains("$50,000.00", emp.getSalary());
        }

        [Theory]
        [InlineData(10000, 0)]             // Below 18,200 -> 0 tax
        [InlineData(18200, 0)]             // Exactly 18,200 -> 0 tax
        [InlineData(20000, 342)]           // (20000 - 18200) * 0.19 = 342
        [InlineData(37000, 3572)]          // (37000 - 18200) * 0.19 = 3572
        [InlineData(50000, 7797)]          // 3572 + (50000 - 37000) * 0.325 = 3572 + 4225 = 7797
        [InlineData(90000, 20797)]         // Threshold for next bracket
        [InlineData(100000, 24497)]        // 20797 + (100000 - 90000) * 0.37 = 20797 + 3700 = 24497
        [InlineData(200000, 63096)]        // 54096 + (200000 - 180000) * 0.45 = 54096 + 9000 = 63096
        public void Employee_Tax_ShouldCalculateCorrectly(double salary, double expectedTax)
        {
            Employee emp = new Employee("Test", salary);
            double tax = emp.Tax();
            Assert.Equal(expectedTax, tax, 1); // Allow small delta for double precision
        }

        [Fact]
        public void Employee_RaiseSalary_ShouldIncreaseAmount()
        {
            Employee emp = new Employee("Bob", 1000);
            emp.raiseSalary(10); // 10% raise -> 1100
            
            // getSalary returns formatted string, check contains
            Assert.Contains("$1,100.00", emp.getSalary());
        }
    }
}

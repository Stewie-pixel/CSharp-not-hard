using Xunit;
using Task1_Mobile;

namespace SIT232_Practical_2._1P.Tests
{
    public class MobileTests
    {
        [Fact]
        public void Mobile_Initialization_ShouldSetValuesCorrectly()
        {
            // Arrange
            string accType = "Monthly";
            string device = "Samsung Galaxy S6";
            string number = "07712223344";
            
            // Act
            Mobile mobile = new Mobile(accType, device, number);

            // Assert
            Assert.Equal(accType, mobile.getAccType());
            Assert.Equal(device, mobile.getDevice());
            Assert.Equal(number, mobile.getNumber());
            // Balance should start at 0.0, formatted as currency
            Assert.Contains("$0.00", mobile.getBalance()); 
        }

        [Fact]
        public void Mobile_AddCredit_ShouldIncreaseBalance()
        {
            // Arrange
            Mobile mobile = new Mobile("PAYG", "Pixel 5", "07712345678");
            double amount = 10.0;

            // Act
            mobile.addCredit(amount);

            // Assert
            // Expecting $10.00
            Assert.Contains("$10.00", mobile.getBalance());
        }

        [Fact]
        public void Mobile_MakeCall_ShouldDecreaseBalanceCorrectly()
        {
            // Arrange
            Mobile mobile = new Mobile("PAYG", "Pixel 5", "07712345678");
            mobile.addCredit(10.0); // Start with 10.0
            int minutes = 5;
            double costPerMinute = 0.245;
            double expectedCost = minutes * costPerMinute; // 1.225
            double expectedBalance = 10.0 - expectedCost; // 8.775

            // Act
            mobile.makeCall(minutes);

            // Assert
            // The getBalance returns a formatted string, so checking strict double equality is tricky.
            // But we can check if the string representation matches roughly.
            // 8.775 might round to $8.78 or $8.77 depending on culture/format.
            // Let's verify logic by checking if balance decreased.
            Assert.DoesNotContain("$10.00", mobile.getBalance());
            // Since we don't have a getRawBalance(), we rely on string output.
            // $8.78 is likely the output.
            Assert.Contains("$8.78", mobile.getBalance());
        }

        [Fact]
        public void Mobile_SendText_ShouldDecreaseBalanceCorrectly()
        {
            // Arrange
            Mobile mobile = new Mobile("PAYG", "Pixel 5", "07712345678");
            mobile.addCredit(5.0);
            int texts = 2;
            double costPerText = 0.078;
            double expectedCost = texts * costPerText; // 0.156
            
            // Act
            mobile.sendText(texts);

            // Assert
            Assert.DoesNotContain("$5.00", mobile.getBalance());
            // 5.0 - 0.156 = 4.844. Should round to $4.84
            Assert.Contains("$4.84", mobile.getBalance());
        }

        [Fact]
        public void Mobile_Setters_ShouldUpdateValues()
        {
             // Arrange
            Mobile mobile = new Mobile("Monthly", "Old Phone", "000");

            // Act
            mobile.setAccType("PAYG");
            mobile.setDevice("New Phone");
            mobile.setNumber("111");
            mobile.setBalance(100.0);

            // Assert
            Assert.Equal("PAYG", mobile.getAccType());
            Assert.Equal("New Phone", mobile.getDevice());
            Assert.Equal("111", mobile.getNumber());
            Assert.Contains("$100.00", mobile.getBalance());
        }
    }
}

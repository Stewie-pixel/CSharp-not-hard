using NUnit.Framework;
using System;
using TheAccountClass;

namespace Account.Tests
{
    public class AccountTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestWithdrawBeforeDeposit_InsufficientFunds_ReturnsFalse()
        {
            // Case 1: Withdraw before deposit (or just withdraw > balance on a new account)
            // Arrange
            var account = new TheAccountClass.Account("Test User", 0m);

            // Act
            bool result = account.Withdraw(50m);

            // Assert
            Assert.IsFalse(result, "Withdrawal should fail when balance is insufficient.");
        }

        [Test]
        public void TestInvalidDeposit_NegativeAmount_ReturnsFalse()
        {
            // Case 2: Invalid number (negative deposit)
            // Arrange
            var account = new TheAccountClass.Account("Test User", 100m);

            // Act
            bool result = account.Deposit(-50m);

            // Assert
            Assert.IsFalse(result, "Deposit should fail when amount is negative.");
        }

        [Test]
        public void TestInvalidWithdraw_NegativeAmount_ReturnsFalse()
        {
            // Case 3: Invalid number (negative withdraw)
            // Arrange
            var account = new TheAccountClass.Account("Test User", 100m);

            // Act
            bool result = account.Withdraw(-10m);

            // Assert
            Assert.IsFalse(result, "Withdrawal should fail when amount is negative.");
        }

        [Test]
        public void TestWithdraw_ValidAmount_ReturnsTrue()
        {
            // Standard case
            // Arrange
            var account = new TheAccountClass.Account("Test User", 100m);

            // Act
            bool result = account.Withdraw(50m);

            // Assert
            Assert.IsTrue(result, "Withdrawal should succeed for valid amount and sufficient balance.");
        }

        [Test]
        public void TestDeposit_ValidAmount_ReturnsTrue()
        {
            // Standard case
            // Arrange
            var account = new TheAccountClass.Account("Test User", 100m);

            // Act
            bool result = account.Deposit(50m);

            // Assert
            Assert.IsTrue(result, "Deposit should succeed for valid positive amount.");
        }
    }
}

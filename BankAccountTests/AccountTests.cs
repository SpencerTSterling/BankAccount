using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Tests
{
    [TestClass()]
    public class AccountTests
    {
        private Account acc; // a new account

        [TestInitialize] // runs code before each test
        public void Initialize()
        {
            acc = new Account();
        }

        [TestMethod()]
        [TestCategory("Deposit")]
        public void Deposit_PositiveAmount_AddsToBalance()
        {
            /// AAA - Arrange Act Assert
            
            // Arrange - creating variables/objectys
            const double startBalance = 0;
            const double initialDeposit = 100;


            // Act - Execute method under test
            acc.Deposit(initialDeposit);

            // Assert - Check a condition
            Assert.AreEqual(startBalance + initialDeposit, acc.Balance);
        }

        [TestMethod()]
        [TestCategory("Deposit")]
        public void Deposit_PositiveAmount_ReturnsUpdatedBalance()
        {
            // Arrange
            Account acc = new Account();

            // Act
            double initialBalance = 0;
            double depositAmount = 10.55;

            double newBalance = acc.Deposit(depositAmount);

            // Assert
            double expectedAmount = initialBalance + depositAmount;
            Assert.AreEqual(expectedAmount, newBalance);
        }

        [TestMethod()]
        [TestCategory("Deposit")]
        public void Deposit_MultipleAmounts_ReturnsAccumulatedBalance()
        {
            //Arrange
            Account acc = new Account();
            double dep1 = 10;
            double dep2 = 25;
            double expectedBalance = dep1 + dep2;

            // Act
            acc.Deposit(dep1);
            double finalBalance = acc.Deposit(dep2);

            // Assert
            Assert.AreEqual(expectedBalance, finalBalance);
        }

        [TestMethod()]
        [TestCategory("Deposit")]
        public void Deposit_NegativeAmount_ThrowsArgumentException()
        {
            //Arrange
            Account acc = new Account();
            double negativeDeposit = -1;

            //Act
           // acc.Deposit(negativeDeposit);

            //Assert => Act
            Assert.ThrowsException<ArgumentException>
                (
                    () => acc.Deposit(negativeDeposit)
                );
        }

        // data driven tests

        [TestMethod]
        [TestCategory("Deposit")]
        [DataRow(10000)]
        [DataRow(112233)]
        [DataRow(double.MaxValue)]
        public void Deposit_TooLarge_ThrowsArgumentException(double tooLargeDeposit)
        {
            Account acc = new Account();

            Assert.ThrowsException<ArgumentException>(() => acc.Deposit(tooLargeDeposit) );
        }

        [TestMethod()]
        [TestCategory("Deposit")]
        [Priority(1)]
        [DataRow(100)]
        [DataRow(0.01)]
        [DataRow(9999.99)]
        public void Deposit_PositiveDataAmount_AddsToBalance(double initialDeposit)
        {
            /// AAA - Arrange Act Assert

            // Arrange - creating variables/objectys
            Account acc = new Account();
            const double startBalance = 0;


            // Act - Execute method under test
            acc.Deposit(initialDeposit);

            // Assert - Check a condition
            Assert.AreEqual(startBalance + initialDeposit, acc.Balance);
        }

        // withdraw tests

        [TestMethod]
        [TestCategory("Withdraw")]
        [DataRow(100, 50)]
        [DataRow(100, 100)]
        [DataRow(50, 50)]
        [DataRow(9.99, 9.99)]
        public void Withdraw_PositiveAmount_SubtractsFromBalance(double initialDeposit, double withdrawAmount)
        {
            //Arrange 
            double expectedBalance = initialDeposit - withdrawAmount;
            
            //Act
            acc.Deposit(initialDeposit);
            acc.Withdraw(withdrawAmount);

            //Assert
            Assert.AreEqual(expectedBalance, acc.Balance);
        }

        [TestMethod]
        [TestCategory("Withdraw")]
        public void Withdraw_MoreThanBalance_ThrowsArgumentException()
        {
            // an account created w/ default constructor has 0 blance
            Account myAcc = new Account();

            double withdrawAmount = 1000;

            Assert.ThrowsException<ArgumentException>(() => myAcc.Withdraw(withdrawAmount));
            
        }

        [TestMethod]
        [TestCategory("Withdraw")]
        public void WithDraw_NegativeAmount_ThrowsArugmentException()
        {
            double negativeWithdraw = -1;

            //Assert => Act
            Assert.ThrowsException<ArgumentException>
                ( () => acc.Withdraw(negativeWithdraw) );
        }

    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using testing_application;

namespace testing_tests
{
    [TestClass]
    public class SavingsAccountTest
    {
        [TestMethod]
        public void depositAndWithdrawal()
        {
            SavingsAccount account = new SavingsAccount();
            account.deposit(100);
            Assert.AreEqual(100, account.getBalance());
            account.withdraw(50);
            Assert.AreEqual(50, account.getBalance());
        }

        [TestMethod]
        public void navigateBalanceIsJustFine()
        {
            SavingsAccount account = new SavingsAccount();
            account.withdraw(75);
            Assert.AreEqual(-75, account.getBalance());
        }

        [TestMethod]
        public void nextYear()
        {
            SavingsAccount account = new SavingsAccount();
            account.deposit(10000);
            SavingsAccount nextYear = account.nextYear(10);
            Assert.AreEqual(11000, nextYear.getBalance());
        }
    }
}

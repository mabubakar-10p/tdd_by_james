using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using testing_application;

namespace testing_tests
{
    [TestClass]
    public class SavingsAccountYearTest
    {
        [TestMethod]
        public void getStartingBalance()
        {
            SavingsAccountYear account = newAccount();
            Assert.AreEqual(10000,account.getStartingBalance());
        }

        [TestMethod]
        public void getEndingBalanceMatchesConstructor()
        {
            Assert.AreEqual(11000, newAccount().getEndingBalance(25));
        }
        [TestMethod]
        public void startingPrincipalMatchesConstructor()
        {
            SavingsAccountYear year = new SavingsAccountYear(10000, 3000, 10);
            Assert.AreEqual(3000, year.getStartingPrincipal());
        }

        [TestMethod]
        public void getInterestRateMatchesConstructor()
        {
            Assert.AreEqual(10, newAccount().getInterestRate());
        }

        [TestMethod]
        public void startingCapitalGainsIsStartingBalanceMinusStartingPrincipal()
        {
            SavingsAccountYear year = new SavingsAccountYear(10000, 3000, 10);
            Assert.AreEqual(7000, year.startingcapitalGains());
        }

        [TestMethod]
        public void nextYearsStartingBalanceEqualThisYearEndingBalance()
        {
            SavingsAccountYear thisYear = newAccount();
            Assert.AreEqual(thisYear.getEndingBalance(25), thisYear.nextYear(25).getStartingBalance());
        }

        [TestMethod]
        public void nextYearsInterestRateEqualThisYearInterestRate()
        {
            SavingsAccountYear thisYear = newAccount();
            Assert.AreEqual(thisYear.getInterestRate(), thisYear.nextYear(25).getInterestRate());
        }

        [TestMethod]
        public void withdrawingFundsOccurAtTheBeginingOfTheYear()
        {
            SavingsAccountYear year = newAccount();
            year.withdraw(1000);
            Assert.AreEqual(9900,year.getEndingBalance(25));
        }
        [TestMethod]
        public void mutipleWithdrawlsInAYear()
        {
            SavingsAccountYear year = newAccount() ;
            year.withdraw(1000);
            year.withdraw(2000);
            Assert.AreEqual(3000, year.getTotalWithdrawn());
        }
        [TestMethod]
        public void capitalGainsWithdrawn()
        {
            SavingsAccountYear year = new SavingsAccountYear(10000, 3000, 10); ;
            Assert.AreEqual(3000, year.getStartingPrincipal());
            year.withdraw(1000);
            Assert.AreEqual(0, year.capitalGainsWithdrawn());
            year.withdraw(3000);
            Assert.AreEqual(1000, year.capitalGainsWithdrawn());
        }
   
        
        [TestMethod]
        public void endingPrincipal()
        {
            SavingsAccountYear year = new SavingsAccountYear(10000, 3000, 10);
            Assert.AreEqual(3000,year.getStartingPrincipal());
            year.withdraw(2000);
            Assert.AreEqual(1000, year.endingPrincipal());
        }
        [TestMethod]
        public void endingPrincipalNeverGoesBelowZero()
        {
            SavingsAccountYear year = new SavingsAccountYear(10000, 3000, 10);
            Assert.AreEqual(3000, year.getStartingPrincipal());
            year.withdraw(4000);
            Assert.AreEqual(0, year.endingPrincipal());
        }
        [TestMethod]
        public void capitalGainsTaxIncured_NeedsToCoverCapitalGainsWithdrawn_AndAdditionalCapitalGainsWithdrawnToPayCapitalGainsTax()
        {
            SavingsAccountYear year = new SavingsAccountYear(10000, 3000, 10);
            year.withdraw(5000);
            Assert.AreEqual(2000,year.capitalGainsWithdrawn());
            Assert.AreEqual(666,year.capitalGainsTaxIncured(25));
        }
        [TestMethod]
        public void capitalGainsTaxIsIncludedInEndingBalance()
        {
            SavingsAccountYear year = new SavingsAccountYear(10000, 3000, 10);
            int amountWithdrawn = 5000;
            year.withdraw(amountWithdrawn);
            int expectedCapitalGainsTax = 666;
            Assert.AreEqual(expectedCapitalGainsTax, year.capitalGainsTaxIncured(25));
            int expectedStartingBalanceAfterWithdrawls = 10000 - amountWithdrawn - expectedCapitalGainsTax;
            Assert.AreEqual((int)(expectedStartingBalanceAfterWithdrawls*1.10), year.getEndingBalance(25));
        }
        private SavingsAccountYear newAccount()
        {
            SavingsAccountYear account = new SavingsAccountYear(10000,10000, 10);
            return account;
        }
    }
}

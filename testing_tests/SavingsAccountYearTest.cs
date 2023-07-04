﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            Assert.Equals(10000,account.getStartingBalance());
        }

        [TestMethod]
        public void getEndingBalanceMatchesConstructor()
        {
            Assert.Equals(10000, newAccount().getEndingBalance());
        }

        [TestMethod]
        public void getInterestRateMatchesConstructor()
        {
            Assert.Equals(10, newAccount().getInterestRate());
        }

        [TestMethod]
        public void nextYearsStartingBalanceEqualThisYearEndingBalance()
        {
            SavingsAccountYear thisYear = newAccount();
            Assert.Equals(thisYear.getEndingBalance(), thisYear.nextYear().getStartingBalance());
        }

        [TestMethod]
        public void nextYearsInterestRateEqualThisYearInterestRate()
        {
            SavingsAccountYear thisYear = newAccount();
            Assert.Equals(thisYear.getInterestRate(), thisYear.nextYear().getInterestRate());
        }

        [TestMethod]
        public void withdrawingFundsOccurAtTheBeginingOfTheYear()
        {
            SavingsAccountYear year = newAccount();
            year.withdraw(1000);
            Assert.Equals(9000,year.getEndingBalance());
        }

        [TestMethod]
        public void withdrawingMoreThanPricipleIncursCapitalGainTax()
        {
            SavingsAccountYear year = new SavingsAccountYear(10000,7000,10);
            year.withdraw(3000);
            Assert.Equals(7700, year.getEndingBalance());
            year.withdraw(5000);
            Assert.Equals(2000+200-(1250), year.getEndingBalance());
        }

        private SavingsAccountYear newAccount()
        {
            SavingsAccountYear account = new SavingsAccountYear(10000, 10);
            return account;
        }
    }
}
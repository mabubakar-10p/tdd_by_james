﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using testing_application;

namespace testing_tests
{
    [TestClass]
    public class StockMarketYearTest
    {
        private const int CapitalGainsTaxRate = 25;
        private const int StartingBalance = 10000;
        private const int StartingPrincipal = 3000;
        private const int InterestRate = 10;

        [TestMethod]
        public void startingValues ()
        {
            StockMarketYear year = newYear();
            Assert.AreEqual(StartingBalance,year.getStartingBalance(),"Starting Balance");
            Assert.AreEqual(StartingPrincipal, year.getStartingPrincipal(),"Starting Principal");
            Assert.AreEqual(InterestRate, year.getInterestRate(), "Interest Rate");
            Assert.AreEqual(CapitalGainsTaxRate, year.getCapitalGainsTaxRate(), "Capital Gains Tax Rate");
            Assert.AreEqual(0, year.getTotalWithdrawn(), "Total Withdrawn default");
        }


        [TestMethod]
        public void capitalGainsTax()
        {
            StockMarketYear year = newYear();
            year.withdraw(4000);
            Assert.AreEqual(333, year.capitalGainsTaxIncured(), "capital gains tax includes tax on withdrawals to cover capital gains");
            Assert.AreEqual(4333, year.getTotalWithdrawn(), "total withdrawn includes capital gains tax");
        }

        [TestMethod]
        public void interestEarned()
        {
            StockMarketYear year = newYear();
            Assert.AreEqual(1000, year.getInterestEarned(), "basic interest earned");
            year.withdraw(2000);
            Assert.AreEqual(800, year.getInterestEarned(), "withdrawals dont earn interest");
            year.withdraw(2000);
            Assert.AreEqual(566, year.getInterestEarned(), "capital gains tax withdrawals dont earn interest");
        }

        [TestMethod]
        public void endingPrincipal()
        {
            StockMarketYear year = newYear();
            year.withdraw(1000);
            Assert.AreEqual(2000, year.endingPrincipal(), "ending principal considers withdrawals");
            year.withdraw(500);
            Assert.AreEqual(1500, year.endingPrincipal(), "ending principal totals mutiple withdrawals");
            year.withdraw(3000);
            Assert.AreEqual(0, year.endingPrincipal(), "ending principalnever goes below zero");
        }

       

        [TestMethod]
        public void endingBalance()
        {
            StockMarketYear year = newYear();
            Assert.AreEqual(11000, year.getEndingBalance(), "ending balance includes interest");
            year.withdraw(1000);
            Assert.AreEqual(9900, year.getEndingBalance(), "ending balance includes withdrawals");
            year.withdraw(3000);
            Assert.AreEqual(6233, year.getEndingBalance(), "ending balance includes capital gains tax withdrawals");
        }
       
        [TestMethod]
        public void nextYearStartingValuesMatchesThisYearEndingValues()
        {
            StockMarketYear thisYear = newYear();
            StockMarketYear nextYear = thisYear.nextYear();
            Assert.AreEqual(thisYear.getEndingBalance(), nextYear.getStartingBalance(),"Starting Balance");
            Assert.AreEqual(thisYear.endingPrincipal(), nextYear.getStartingPrincipal(),"Starting Principal");
            Assert.AreEqual(thisYear.getInterestRate(), nextYear.getInterestRate(),"Interest");
            Assert.AreEqual(thisYear.getCapitalGainsTaxRate(), nextYear.getCapitalGainsTaxRate(), "capital gains tax rate");

        }

        private StockMarketYear newYear()
        {
            return new StockMarketYear(StartingBalance, StartingPrincipal, InterestRate, CapitalGainsTaxRate);
        }
    }
}

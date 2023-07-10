using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using testing_application;

namespace testing_tests
{
    [TestClass]
    public class StockMarketYearTest
    {
        private const int TaxRate = 25;
        private const int StartingBalance = 10000;
        private const int StartingPrincipal = 3000;
        private const int InterestRate = 10;

        [TestMethod]
        public void startingValues ()
        {
            StockMarketYear year = newYear();
            Assert.AreEqual(10000,year.getStartingBalance(),"Starting Balance");
            Assert.AreEqual(3000, year.getStartingPrincipal(),"Starting Principal");
            Assert.AreEqual(10, year.getInterestRate(), "Interest Rate");
            Assert.AreEqual(0, year.getTotalWithdrawn(TaxRate), "Total Withdrawn default");
        }


        [TestMethod]
        public void capitalGainsTax()
        {
            StockMarketYear year = newYear();
            year.withdraw(4000);
            Assert.AreEqual(333, year.capitalGainsTaxIncured(TaxRate), "capital gains tax includes tax on withdrawals to cover capital gains");
            Assert.AreEqual(4333, year.getTotalWithdrawn(TaxRate), "total withdrawn includes capital gains tax");
        }

        [TestMethod]
        public void interestEarned()
        {
            StockMarketYear year = newYear();
            Assert.AreEqual(1000, year.getInterestEarned(TaxRate), "basic interest earned");
            year.withdraw(2000);
            Assert.AreEqual(800, year.getInterestEarned(TaxRate), "withdrawals dont earn interest");
            year.withdraw(2000);
            Assert.AreEqual(566, year.getInterestEarned(TaxRate), "capital gains tax withdrawals dont earn interest");
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
            Assert.AreEqual(11000, year.getEndingBalance(TaxRate), "ending balance includes interest");
            year.withdraw(1000);
            Assert.AreEqual(9900, year.getEndingBalance(TaxRate), "ending balance includes withdrawals");
            year.withdraw(3000);
            Assert.AreEqual(6233, year.getEndingBalance(TaxRate), "ending balance includes capital gains tax withdrawals");
        }
       
        [TestMethod]
        public void nextYearStartingValuesMatchesThisYearEndingValues()
        {
            StockMarketYear thisYear = newYear();
            StockMarketYear nextYear = thisYear.nextYear(TaxRate);
            Assert.AreEqual(thisYear.getEndingBalance(TaxRate), nextYear.getStartingBalance(),"Starting Balance");
            Assert.AreEqual(thisYear.endingPrincipal(), nextYear.getStartingPrincipal(),"Starting Principal");
            Assert.AreEqual(thisYear.getInterestRate(), nextYear.getInterestRate(),"Interest");
        }

        private StockMarketYear newYear()
        {
            return new StockMarketYear(StartingBalance, StartingPrincipal, InterestRate);
        }
    }
}

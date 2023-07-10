using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using testing_application;

namespace testing_tests
{
    [TestClass]
    public class StockMarketYearTest
    {
        private const int TaxRate = 25;

        [TestMethod]
        public void startingValues ()
        {
            StockMarketYear year = new StockMarketYear(10000, 3000, 10);
            Assert.AreEqual(10000,year.getStartingBalance(),"Starting Balance");
            Assert.AreEqual(3000, year.getStartingPrincipal(),"Starting Principal");
            Assert.AreEqual(10, newAccount().getInterestRate(), "Interest Rate");
            Assert.AreEqual(0, year.getTotalWithdrawn(TaxRate), "Total Withdrawn default");
        }

        [TestMethod]
        public void endingPrincipal()
        {
            StockMarketYear year = new StockMarketYear(10000, 3000, 10);
            year.withdraw(1000);
            Assert.AreEqual(2000, year.endingPrincipal(),"ending principal considers withdrawals");
            year.withdraw(500);
            Assert.AreEqual(1500, year.endingPrincipal(),"ending principal totals mutiple withdrawals");
            year.withdraw(3000);
            Assert.AreEqual(0, year.endingPrincipal(),"ending principalnever goes below zero");
        }

        [TestMethod]
        public void interestEarned()
        {
            StockMarketYear year = new StockMarketYear(10000, 3000, 10);
            Assert.AreEqual(1000, year.getInterestEarned(25), "basic interest earned");
            year.withdraw(2000);
            Assert.AreEqual(800, year.getInterestEarned(25), "withdrawals dont earn interest");
        }        

        [TestMethod]
        public void totalWithdrawnIncludingCapitalGains()
        {
            StockMarketYear year = new StockMarketYear(10000, 0, 10);
            year.withdraw(1000);
            Assert.AreEqual(333, year.capitalGainsTaxIncured(TaxRate),"capital gains tax");
            Assert.AreEqual(1333, year.getTotalWithdrawn(TaxRate),"total withdrawn");
        }

        [TestMethod]
        public void capitalGainsTaxesDoNotEarnInterest()
        {
            StockMarketYear year = new StockMarketYear(10000, 0, 10);
            year.withdraw(1000);
            Assert.AreEqual(1000, year.capitalGainsWithdrawn(),"capital gains withdrawn");
            Assert.AreEqual(333, year.capitalGainsTaxIncured(TaxRate),"capital gains tax");
            Assert.AreEqual(1333, year.getTotalWithdrawn(TaxRate),"total withdrawn");
            Assert.AreEqual(866, year.getInterestEarned(TaxRate),"interest earned");
        }

        [TestMethod]
        public void getEndingBalanceAppliesInterestRate()
        {
            Assert.AreEqual(11000, newAccount().getEndingBalance(TaxRate));
        }

       
        [TestMethod]
        public void mutipleWithdrawlsInAYearAreTotaled()
        {
            StockMarketYear year = newAccount() ;
            year.withdraw(1000);
            year.withdraw(2000);
            Assert.AreEqual(3000, year.getTotalWithdrawn(TaxRate));
        }
        [TestMethod]
        public void withdrawingMoreThanPrincipalTakesFromCapitalGains()
        {
            StockMarketYear year = new StockMarketYear(10000, 3000, 10); ;
            year.withdraw(1000);
            Assert.AreEqual(0, year.capitalGainsWithdrawn());
            year.withdraw(3000);
            Assert.AreEqual(1000, year.capitalGainsWithdrawn());
        }
   
        
       
       
        [TestMethod]
        public void capitalGainsTaxIncured_NeedsToCoverCapitalGainsWithdrawn_AndAdditionalCapitalGainsWithdrawnToPayCapitalGainsTax()
        {
            StockMarketYear year = new StockMarketYear(10000, 3000, 10);
            year.withdraw(5000);
            Assert.AreEqual(2000,year.capitalGainsWithdrawn());
            Assert.AreEqual(666,year.capitalGainsTaxIncured(TaxRate));
        }
        [TestMethod]
        public void capitalGainsTaxIsIncludedInEndingBalance()
        {
            StockMarketYear year = new StockMarketYear(10000, 3000, 10);
            int amountWithdrawn = 5000;
            year.withdraw(amountWithdrawn);
            int expectedCapitalGainsTax = 666;
            Assert.AreEqual(expectedCapitalGainsTax, year.capitalGainsTaxIncured(TaxRate));
            int expectedStartingBalanceAfterWithdrawls = 10000 - amountWithdrawn - expectedCapitalGainsTax;
            Assert.AreEqual((int)(expectedStartingBalanceAfterWithdrawls*1.10), year.getEndingBalance(TaxRate));
        }

        [TestMethod]
        public void nextYears()
        {
            StockMarketYear thisYear = newAccount();
            StockMarketYear nextYear = thisYear.nextYear(TaxRate);
            Assert.AreEqual(thisYear.getEndingBalance(TaxRate), nextYear.getStartingBalance(),"Starting Balance");
            Assert.AreEqual(thisYear.endingPrincipal(), nextYear.getStartingPrincipal(),"Starting Principal");
            Assert.AreEqual(thisYear.getInterestRate(), nextYear.getInterestRate(),"Interest");
        }   

        private StockMarketYear newAccount()
        {
            StockMarketYear account = new StockMarketYear(10000,10000, 10);
            return account;
        }
    }
}

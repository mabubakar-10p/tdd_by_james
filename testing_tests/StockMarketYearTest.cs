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
        public void getStartingBalanceMatchesConstructor()
        {
            StockMarketYear account = newAccount();
            Assert.AreEqual(10000,account.getStartingBalance());
        }

        [TestMethod]
        public void startingPrincipalMatchesConstructor()
        {
            StockMarketYear year = new StockMarketYear(10000, 3000, 10);
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
            StockMarketYear year = new StockMarketYear(10000, 3000, 10);
            Assert.AreEqual(7000, year.startingcapitalGains());
        }
       
        [TestMethod]
        public void endingPrincipalConsidersWithdrawls()
        {
            StockMarketYear year = new StockMarketYear(10000, 3000, 10);
            Assert.AreEqual(3000, year.getStartingPrincipal());
            year.withdraw(2000);
            Assert.AreEqual(1000, year.endingPrincipal());
        }

        [TestMethod]
        public void endingPrincipalNeverGoesBelowZero()
        {
            StockMarketYear year = new StockMarketYear(10000, 3000, 10);
            Assert.AreEqual(3000, year.getStartingPrincipal());
            year.withdraw(4000);
            Assert.AreEqual(0, year.endingPrincipal());
        }

        [TestMethod]
        public void interestEarnedIsStartingBalanceCombinedWithInterestRate()
        {
            StockMarketYear year = new StockMarketYear(10000,3000, 10);
            Assert.AreEqual(1000, year.getInterestEarned(TaxRate));
        }

        [TestMethod]
        public void withdrawnFundDoNotEarnInterest()
        {
            StockMarketYear year = newAccount();
            year.withdraw(1000);
            Assert.AreEqual(900, year.getInterestEarned(TaxRate));
        }

        [TestMethod]
        public void totalWithdrawnIncludingCapitalGains()
        {
            StockMarketYear year = new StockMarketYear(10000, 0, 10);
            year.withdraw(1000);
            Assert.AreEqual(333, year.capitalGainsTaxIncured(TaxRate));
            Assert.AreEqual(1333, year.getTotalWithdrawn(TaxRate));
        }

        [TestMethod]
        public void capitalGainsTaxesDoNotEarnInterest()
        {
            StockMarketYear year = new StockMarketYear(10000, 0, 10);
            year.withdraw(1000);
            Assert.AreEqual(1000, year.capitalGainsWithdrawn());
            Assert.AreEqual(333, year.capitalGainsTaxIncured(TaxRate));
            Assert.AreEqual(1333, year.getTotalWithdrawn(TaxRate));
            Assert.AreEqual(866, year.getInterestEarned(TaxRate));
        }
        [TestMethod]
        public void endingCapitalGainsIncludesInterestEarned()
        {
            StockMarketYear year = new StockMarketYear(10000, 3000, 10);
            Assert.AreEqual(7000, year.startingcapitalGains());
            Assert.AreEqual(8000, year.endingcapitalGains(TaxRate));
        }

        [TestMethod]
        public void pendingCapitalGainsIncludesCapitalGainsWithdrawn()
        {
            StockMarketYear year = new StockMarketYear(10000, 0, 10);
            Assert.AreEqual(10000, year.startingcapitalGains());
            year.withdraw(1000);
            Assert.AreEqual(333, year.capitalGainsTaxIncured(TaxRate));
            Assert.AreEqual(866, year.getInterestEarned(TaxRate));
            Assert.AreEqual(9533, year.endingcapitalGains(TaxRate));

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
        public void nextYearsStartingBalanceEqualThisYearEndingBalance()
        {
            StockMarketYear thisYear = newAccount();
            Assert.AreEqual(thisYear.getEndingBalance(TaxRate), thisYear.nextYear(TaxRate).getStartingBalance());
        }

        [TestMethod]
        public void nextYearsInterestRateEqualThisYearInterestRate()
        {
            StockMarketYear thisYear = newAccount();
            Assert.AreEqual(thisYear.getInterestRate(), thisYear.nextYear(TaxRate).getInterestRate());
        }

        private StockMarketYear newAccount()
        {
            StockMarketYear account = new StockMarketYear(10000,10000, 10);
            return account;
        }
    }
}

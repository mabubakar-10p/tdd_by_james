using System;

namespace testing_application
{
    public class StockMarketYear
    {
        private int startingBalance;
        private InterestRate interestRate;
        private TaxRate capitalGainsTaxRate;
        private int startingPrincipal;
        private int totalWithdrawals;

      

        public StockMarketYear(int startingBalance,int startingPrincipal, InterestRate interestRate, TaxRate capitalGainsTaxRate)
        {
            this.startingBalance = startingBalance;
            this.interestRate = interestRate;
            this.capitalGainsTaxRate = capitalGainsTaxRate;
            this.startingPrincipal = startingPrincipal;
            this.totalWithdrawals = 0;
        }
        public int getStartingBalance()
        {
            return startingBalance;
        }

        public int getStartingPrincipal()
        {
            return startingPrincipal;
        }

    
        public InterestRate getInterestRate()
        {
            return interestRate;
        }
        public TaxRate getCapitalGainsTaxRate()
        {
            return capitalGainsTaxRate;
        }
        public void withdraw(int amount)
        {
            this.totalWithdrawals += amount;
        }
        private int capitalGainsWithdrawn()
        {
            return Math.Max(0, -1 * (getStartingPrincipal() - totalWithdrawals));
        }

        public int capitalGainsTaxIncured()
        {
            return capitalGainsTaxRate.compoundTaxFor(capitalGainsWithdrawn());
        }
        public int getTotalWithdrawn()
        {
            return totalWithdrawals + capitalGainsTaxIncured();
        }
        public int getInterestEarned()
        {
            return interestRate.interestOn(startingBalance - getTotalWithdrawn());
        }
        public int getEndingBalance()
        {
            return startingBalance - getTotalWithdrawn() + getInterestEarned();
        }
        public int endingPrincipal()
        {
            return Math.Max(0, getStartingPrincipal() - totalWithdrawals);
        }
      
        public StockMarketYear nextYear()
        {
            return new StockMarketYear(this.getEndingBalance(), this.endingPrincipal(),this.getInterestRate(),this.getCapitalGainsTaxRate());
        }

    }
}

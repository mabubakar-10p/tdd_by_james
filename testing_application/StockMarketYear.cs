using System;

namespace testing_application
{
    public class StockMarketYear
    {
        private Dollars startingBalance;
        private InterestRate interestRate;
        private TaxRate capitalGainsTaxRate;
        private Dollars startingPrincipal;
        private int totalWithdrawals;

      

        public StockMarketYear(Dollars startingBalance,Dollars startingPrincipal, InterestRate interestRate, TaxRate capitalGainsTaxRate)
        {
            this.startingBalance = startingBalance;
            this.interestRate = interestRate;
            this.capitalGainsTaxRate = capitalGainsTaxRate;
            this.startingPrincipal = startingPrincipal;
            this.totalWithdrawals = 0;
        }
        public Dollars getStartingBalance()
        {
            return startingBalance;
        }

        public Dollars getStartingPrincipal()
        {
            return startingPrincipal ;
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
            return Math.Max(0, -1 * (getStartingPrincipal().getAmount() - totalWithdrawals));
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
            return interestRate.interestOn(startingBalance.getAmount() - getTotalWithdrawn());
        }
        public int getEndingBalance()
        {
            return startingBalance.getAmount() - getTotalWithdrawn() + getInterestEarned();
        }
        public int endingPrincipal()
        {
            return startingPrincipal.subtractToZero(new Dollars(totalWithdrawals)).getAmount();
        }
      
        public StockMarketYear nextYear()
        {
            return new StockMarketYear(this.getEndingBalance(), this.endingPrincipal(),this.getInterestRate(),this.getCapitalGainsTaxRate());
        }

    }
}

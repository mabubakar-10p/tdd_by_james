using System;

namespace testing_application
{
    public class StockMarketYear
    {
        private Dollars startingBalance;
        private InterestRate interestRate;
        private TaxRate capitalGainsTaxRate;
        private Dollars startingPrincipal;
        private Dollars totalWithdrawals;

      

        public StockMarketYear(Dollars startingBalance,Dollars startingPrincipal, InterestRate interestRate, TaxRate capitalGainsTaxRate)
        {
            this.startingBalance = startingBalance;
            this.interestRate = interestRate;
            this.capitalGainsTaxRate = capitalGainsTaxRate;
            this.startingPrincipal = startingPrincipal;
            this.totalWithdrawals =new Dollars(0);
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
        public void withdraw(Dollars amount)
        {
            this.totalWithdrawals = totalWithdrawals.add(amount);
        }
        private Dollars capitalGainsWithdrawn()
        {
            return totalWithdrawals.subtractToZero(getStartingPrincipal());   
        }

        public int capitalGainsTaxIncured()
        {
            return capitalGainsTaxRate.compoundTaxFor(capitalGainsWithdrawn().getAmount());
        }
        public Dollars getTotalWithdrawn()
        {
            return totalWithdrawals.add(new Dollars(capitalGainsTaxIncured()));
        }
        public int getInterestEarned()
        {
            return interestRate.interestOn(startingBalance.getAmount() - getTotalWithdrawn().getAmount());
        }
        public Dollars getEndingBalance()
        {
            return startingBalance.subtract(getTotalWithdrawn()).add(new Dollars(getInterestEarned()));
        }
        public int endingPrincipal()
        {
            return startingPrincipal.subtractToZero(totalWithdrawals).getAmount();
        }
      
        public StockMarketYear nextYear()
        {
            return new StockMarketYear(this.getEndingBalance(), new Dollars(this.endingPrincipal()),this.getInterestRate(),this.getCapitalGainsTaxRate());
        }

    }
}

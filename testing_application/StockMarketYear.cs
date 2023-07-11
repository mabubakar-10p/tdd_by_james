using System;

namespace testing_application
{
    public class StockMarketYear
    {
        private int startingBalance;
        private int interestRate;
        private int capitalGainsTaxRate;
        private int startingPrincipal;
        private int totalWithdrawals;

      

        public StockMarketYear(int startingBalance,int startingPrincipal, int interestRate, int capitalGainsTaxRate)
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

    
        public int getInterestRate()
        {
            return interestRate;
        }
        public int getCapitalGainsTaxRate()
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
            double dblTaxRate = capitalGainsTaxRate / 100.0;
            double dblCapitalGains = capitalGainsWithdrawn();

            return (int)((dblCapitalGains / (1 - dblTaxRate)) - dblCapitalGains);
        }
        public int getTotalWithdrawn()
        {
            return totalWithdrawals + capitalGainsTaxIncured();
        }
        public int getInterestEarned()
        {
            return (startingBalance - getTotalWithdrawn()) * interestRate / 100;
        }
        public int getEndingBalance()
        {
            int modifiedStart = startingBalance - getTotalWithdrawn();
            return modifiedStart + getInterestEarned();
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

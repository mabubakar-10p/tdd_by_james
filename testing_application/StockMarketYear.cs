using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing_application
{
    public class StockMarketYear
    {
        private int startingBalance;
        private int interestRate;
        private int startingPrincipal;
        private int totalWithdrawals;

      

        public StockMarketYear(int startingBalance,int startingPrincipal, int interestRate)
        {
            this.startingBalance = startingBalance;
            this.interestRate = interestRate;
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
        public void withdraw(int amount)
        {
            this.totalWithdrawals += amount;
        }
        public int capitalGainsWithdrawn()
        {
            return Math.Max(0, -1 * (getStartingPrincipal() - totalWithdrawals));
        }

        public int capitalGainsTaxIncured(int taxRate)
        {
            double dblTaxRate = taxRate / 100.0;
            double dblCapitalGains = capitalGainsWithdrawn();

            return (int)((dblCapitalGains / (1 - dblTaxRate)) - dblCapitalGains);
        }
        public int getTotalWithdrawn(int capitalGainsTaxRate)
        {
            return totalWithdrawals + capitalGainsTaxIncured(capitalGainsTaxRate);
        }
        public int getInterestEarned(int capitalGainsTaxRate)
        {
            return (startingBalance - getTotalWithdrawn(capitalGainsTaxRate)) * interestRate / 100;
        }
        public int endingPrincipal()
        {
            return Math.Max(0, getStartingPrincipal() - totalWithdrawals);
        }
        public int endingcapitalGains(int capitalGainTaxRate)
        {
            return getEndingBalance(capitalGainTaxRate) - endingPrincipal() ;
        }   
        
        public int getEndingBalance(int capitalGainsTaxRate)
        {
            int modifiedStart = startingBalance - getTotalWithdrawn(capitalGainsTaxRate);
            return modifiedStart + getInterestEarned(capitalGainsTaxRate);
        }



        public StockMarketYear nextYear(int capitalGainsTaxRate)
        {
            return new StockMarketYear(this.getEndingBalance(capitalGainsTaxRate),this.endingPrincipal(),this.getInterestRate());
        }

     

        
      
       

      
    }
}

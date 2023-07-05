using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing_application
{
    public class SavingsAccountYear
    {
        private int startingBalance = 0;
        private int interestRate = 0;
        private int capitalGainsAmount = 0;
        private int startingPrincipal = 0;
        private int totalWithdrawn = 0;

      

        public SavingsAccountYear(int startingBalance,int startingPrincipal, int interestRate)
        {
            this.startingBalance = startingBalance;
            this.interestRate = interestRate;
            this.startingPrincipal = startingPrincipal;
            this.capitalGainsAmount = startingBalance - startingPrincipal;
        }
        public int getStartingBalance()
        {
            return startingBalance;
        }

        public int getEndingBalance(int capitalGainsTaxRate)
        {
            int modifiedStart = startingBalance - getTotalWithdrawn() - capitalGainsTaxIncured(capitalGainsTaxRate);
            return modifiedStart + (modifiedStart * interestRate / 100);
        }
        public int getStartingPrincipal()
        {
            return startingPrincipal - capitalGainsAmount;
        }

        public int startingcapitalGains()
        {
            return getStartingBalance() - getStartingPrincipal();
        }
        public int getInterestRate()
        {
            return interestRate;
        }
        public int endingPrincipal()
        {
            return Math.Max(0, getStartingPrincipal() - getTotalWithdrawn());
        }
        public SavingsAccountYear nextYear(int capitalGainsTaxRate)
        {
            return new SavingsAccountYear(this.getEndingBalance(capitalGainsTaxRate),0, interestRate);
        }

        public void withdraw(int amount)
        {
            this.totalWithdrawn += amount;
        }

        public int getTotalWithdrawn()
        {
            return totalWithdrawn;
        }

        public int capitalGainsWithdrawn()
        {
            return Math.Max(0, -1 * (getStartingPrincipal() - getTotalWithdrawn()));
        }

        public int capitalGainsTaxIncured(int taxRate)
        {
            double dblTaxRate = taxRate / 100.0;
            double dblCapitalGains = capitalGainsWithdrawn();

            return (int)((dblCapitalGains / (1 - dblTaxRate)) - dblCapitalGains);
        }

    }
}

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

        public SavingsAccountYear(int startingBalance, int interestRate) { 
            this.startingBalance = startingBalance;
            this.interestRate = interestRate;
        }

        public SavingsAccountYear(int startingBalance,int capitalGainsAmount, int interestRate)
        {
            this.startingBalance = startingBalance;
            this.interestRate = interestRate;
            this.capitalGainsAmount = capitalGainsAmount;
        }
        public int getStartingBalance()
        {
            return startingBalance;
        }

        public int getEndingBalance()
        {
            return startingBalance + (getStartingBalance() * interestRate / 100);
        }
        public int getInterestRate()
        {
            return interestRate;
        }

        public SavingsAccountYear nextYear()
        {
            return new SavingsAccountYear(this.getEndingBalance(), interestRate);
        }

        public void withdraw(int amount)
        {
            startingBalance -= amount;
        }
    }
}

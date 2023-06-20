using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing_application
{
    public class SavingsAccount
    {
        private int balance = 0;

        public void deposit(int amount)
        {
            balance += amount;
        }

        public int getBalance() { return balance; }

        public void withdraw(int amount)
        {
            balance -= amount;
        }

        public SavingsAccount nextYear(int interestRate)
        {
            SavingsAccount result = new SavingsAccount();
            int newBalance = getBalance() + (getBalance() * interestRate / 100);
            result.deposit(newBalance);
            return result;
        }

    }
}

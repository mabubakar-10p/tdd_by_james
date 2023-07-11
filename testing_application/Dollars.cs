using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing_application
{
    public class Dollars
    {
        private int amount;

        public Dollars(int amount)
        {
            this.amount = amount;
        }
        public int getAmount()
        {
            return amount;
        }
        public Dollars add(Dollars dollars)
        {
            return new Dollars(this.amount + dollars.amount);
        }

        public Dollars subtract(Dollars dollars)
        {
            return new Dollars(this.amount - dollars.amount);
        }

        public Dollars subtractToZero(Dollars dollars)
        {
            int result = this.amount - dollars.amount;
            return new Dollars(Math.Max(0,result));
        }
        public override string ToString()
        {
            return "$"+amount;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Dollars other = (Dollars)obj;
            return amount == other.amount;
        }

        public override int GetHashCode()
        {
            return amount.GetHashCode();
        }

     
    }
}

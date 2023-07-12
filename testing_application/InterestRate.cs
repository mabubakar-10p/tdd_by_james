using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing_application
{
    public class InterestRate
    {
        private decimal rate;

        public InterestRate(double rateAsPercentage) {
            this.rate = (decimal)(rateAsPercentage / 100.0);
        }
        
        public Dollars interestOn(Dollars amount)
        {
            return new Dollars((int)(amount.toInt()  * rate));
        }

        public override string ToString()
        {
            return (rate * 100) + "%";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            InterestRate other = (InterestRate)obj;
            return rate == other.rate;
        }

        public override int GetHashCode()
        {
            return rate.GetHashCode();
        }

    }
}

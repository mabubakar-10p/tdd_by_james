using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing_application
{
    public class TaxRate
    {
        private decimal rate;

        public TaxRate(double rateAsPercentage) {
            this.rate = (decimal)(rateAsPercentage / 100);
        }
        public int getRate()
        {
            return (int)(rate * 100);
        }

        public int simpleTaxFor(int amount)
        {
            return (int)(amount * rate);
        }
        public int compoundTaxFor(int amount)
        {
            return (int)(amount / (1 - rate)) - amount;
        }

        public override string ToString()
        {
            return (rate * 100) + "%";
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}

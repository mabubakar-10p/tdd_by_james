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

        public int taxFor(int amount)
        {
            return (int)(amount * rate);
        }
    }
}

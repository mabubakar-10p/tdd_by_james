namespace testing_application
{
    public class TaxRate
    {
        private decimal rate;

        public TaxRate(double rateAsPercentage) {
            this.rate = (decimal)(rateAsPercentage / 100.0);
        }
      

        public Dollars simpleTaxFor(Dollars amount)
        {
            return new Dollars((int)(rate * amount.toInt()));
        }
        public Dollars compoundTaxFor(Dollars amount)
        {
            return new Dollars((int)(amount.toInt() / (1 - rate)) - amount.toInt());
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

            TaxRate other = (TaxRate)obj;
            return rate == other.rate;
        }

        public override int GetHashCode()
        {
            return rate.GetHashCode();
        }

    }
}

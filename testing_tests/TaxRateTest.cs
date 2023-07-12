using Microsoft.VisualStudio.TestTools.UnitTesting;
using testing_application;

namespace testing_tests
{
    [TestClass]
    public class TaxRateTest
    {
        [TestMethod]
        public void nothing()
        {
            TaxRate taxRate = new TaxRate(0);
            Assert.AreEqual(new Dollars(0), taxRate.simpleTaxFor(new Dollars(1000)));
            Assert.AreEqual(new Dollars(0), taxRate.compoundTaxFor(new Dollars(1000)));
        }
        [TestMethod]
        public void simpleTaxJustAppliesTaxRateToAmount() {
            TaxRate taxRate = new TaxRate(25);
            Assert.AreEqual(new Dollars(250), taxRate.simpleTaxFor(new Dollars(1000)));
        }
        [TestMethod]
        public void compundTaxIsTheAmountofTaxThatIsIncurredIfYouAlsoPayTaxOnTheTax()
        {
            TaxRate taxRate = new TaxRate(25);
            Assert.AreEqual(new Dollars(333), taxRate.compoundTaxFor(new Dollars(1000)));
        }
        [TestMethod]
        public void valueObject()
        {
            TaxRate rate1a = new TaxRate(33);
            TaxRate rate1b = new TaxRate(33);
            TaxRate rate2 = new TaxRate(40);

            Assert.AreEqual("33.00%",rate1a.ToString());
            Assert.IsTrue(rate1a.Equals(rate1b),"same values should be equal");
            Assert.IsFalse(rate1a.Equals(rate2), "different values should be false");
            Assert.IsTrue(rate1a.GetHashCode() == rate1b.GetHashCode(), "same values have same hash code");
        }

      
    }
}

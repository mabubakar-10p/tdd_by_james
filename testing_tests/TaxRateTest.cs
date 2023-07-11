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
            Assert.AreEqual(0, taxRate.taxFor(1000));
        }
    }
}

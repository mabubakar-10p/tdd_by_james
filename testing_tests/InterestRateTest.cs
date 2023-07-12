using Microsoft.VisualStudio.TestTools.UnitTesting;
using testing_application;

namespace testing_tests
{
    [TestClass]
    public class InterestRateTest
    {
        [TestMethod]
        public void nothing()
        {
            InterestRate rate = new InterestRate(0);
            Assert.AreEqual(new Dollars(0), rate.interestOn(new Dollars(1000)));
        }
        [TestMethod]
        public void interest() {
            InterestRate rate = new InterestRate(10);
            Assert.AreEqual(new Dollars(100), rate.interestOn(new Dollars(1000)));
        }
       
        [TestMethod]
        public void valueObject()
        {
            InterestRate rate1a = new InterestRate(10);
            InterestRate rate1b = new InterestRate(10);
            InterestRate rate2 = new InterestRate(20);

            Assert.AreEqual("10.0%",rate1a.ToString());
            Assert.IsTrue(rate1a.Equals(rate1b),"same values rates be equal");
            Assert.IsFalse(rate1a.Equals(rate2), "different rates should be false");
            Assert.IsTrue(rate1a.GetHashCode() == rate1b.GetHashCode(), "same rate have same hash code");
        }

      
    }
}

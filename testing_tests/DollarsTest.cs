using Microsoft.VisualStudio.TestTools.UnitTesting;
using testing_application;

namespace testing_tests
{
    [TestClass]
    public class DollarsTest
    {
        [TestMethod]
        public void addition()
        {
            Assert.AreEqual(new Dollars(40), new Dollars(10).add(new Dollars(30)));
        }
        [TestMethod]
        public void subtraction()
        {
            Assert.AreEqual(new Dollars(20), new Dollars(50).subtract(new Dollars(30)),"positive result");
            Assert.AreEqual(new Dollars(-60), new Dollars(40).subtract(new Dollars(100)),"negative result");
        }

        [TestMethod]
        public void subtractToZero()
        {
            Assert.AreEqual(new Dollars(20), new Dollars(50).subtractToZero(new Dollars(30)), "positive result");
            Assert.AreEqual(new Dollars(0), new Dollars(40).subtractToZero(new Dollars(100)), "non negative result -- return zero instead");
        }

        [TestMethod]
        public void valueObject()
        {
            Dollars dollars1a = new Dollars(10);
            Dollars dollars1b = new Dollars(10);
            Dollars dollars2 = new Dollars(20);

            Assert.AreEqual("$10", dollars1a.ToString());
            Assert.IsTrue(dollars1a.Equals(dollars1b), "dollars with same amount should be equal");
            Assert.IsFalse(dollars1a.Equals(dollars2), "dollars with different amount should not be equal");
            Assert.IsTrue(dollars1a.GetHashCode() == dollars1b.GetHashCode(), "equal dollars should have same hash code");
        }
             
    }
}

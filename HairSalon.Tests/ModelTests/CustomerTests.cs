using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class CustomerTest
    {

        [TestMethod]
        public void CustomerConstructor_CreatesInstanceOfCustomer_Customer()
        {
          Customer newCustomer = new Customer();
          Assert.AreEqual(typeof(Customer), newCustomer.GetType());
        }

    }
}

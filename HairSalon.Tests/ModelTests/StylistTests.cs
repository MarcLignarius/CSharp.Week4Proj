using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistTest : IDisposable
    {

        public void Dispose()
        {
          Stylist.ClearAll();
        }

        [TestMethod]
        public void StylistConstructor_CreatesInstanceOfStylist_Stylist()
        {
            //Arrange
            Stylist newStylist = new Stylist("Sara", "Sara is the best");

            //Assert
            Assert.AreEqual(typeof(Stylist), newStylist.GetType());
        }

        [TestMethod]
        public void GetName_ReturnsName_String()
        {
            //Arrange
            string name = "Sara";
            string description = "Sara is the best";
            Stylist newStylist = new Stylist(name, description);

            //Act
            string result = newStylist.GetName();

            //Assert
            Assert.AreEqual(name, result);
        }

        [TestMethod]
        public void GetId_ReturnsCategoryId_Int()
        {
            //Arrange
            string name = "Sara";
            string description = "Sara is the best";
            Stylist newStylist = new Stylist(name, description);

            //Act
            int result = newStylist.GetId();

            //Assert
            Assert.AreEqual(1, result);
        }

    }
}

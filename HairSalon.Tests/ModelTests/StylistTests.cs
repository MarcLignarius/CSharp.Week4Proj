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

        // [TestMethod]
        // public void GetId_ReturnsStylistId_Int()
        // {
        //     //Arrange
        //     string name = "Sara";
        //     string description = "Sara is the best";
        //     Stylist newStylist = new Stylist(name, description);
        //
        //     //Act
        //     int result = newStylist.GetId();
        //
        //     //Assert
        //     Assert.AreEqual(1, result);
        // }

        // [TestMethod]
        // public void GetAll_ReturnsAllStylistObjects_StylistList()
        // {
        //   //Arrange
        //   string name1 = "Sara";
        //   string description1 = "Sara is the best";
        //   string name2 = "Jen";
        //   string description2 = "Jen rocks";
        //   Stylist newStylist1 = new Stylist(name1, description1);
        //   Stylist newStylist2 = new Stylist(name2, description2);
        //   List<Stylist> newList = new List<Stylist> { newStylist1, newStylist2 };
        //
        //   //Act
        //   List<Stylist> result = Stylist.GetAll();
        //
        //   //Assert
        //   CollectionAssert.AreEqual(newList, result);
        // }

        // [TestMethod]
        // public void Find_ReturnsCorrectStylist_Stylist()
        // {
        //     //Arrange
        //     string name1 = "Sara";
        //     string description1 = "Sara is the best";
        //     string name2 = "Jen";
        //     string description2 = "Jen rocks";
        //     Stylist newStylist1 = new Stylist(name1, description1);
        //     Stylist newStylist2 = new Stylist(name2, description2);
        //     List<Stylist> newList = new List<Stylist> { newStylist1, newStylist2 };
        //
        //     //Act
        //     Stylist result = Stylist.Find(2);
        //
        //     //Assert
        //     Assert.AreEqual(newStylist2, result);
        // }

        [TestMethod]
        public void GetClients_ReturnsEmptyClientList_ClientList()
        {
            //Arrange
            string name = "Sara";
            string description = "Sara is the best";
            Stylist newStylist = new Stylist(name, description);
            List<Client> newList = new List<Client> { };

            //Act
            List<Client> result = newStylist.GetClients();

            //Assert
            CollectionAssert.AreEqual(newList, result);
        }

        // [TestMethod]
        // public void AddClient_AssociatesClientWithStylist_ClientList()
        // {
        //     //Arrange
        //     string firstName = "Marc";
        //     string lastName = "Davies";
        //     string phoneNumber = "3232866556";
        //     string emailAddress = "marcdaviesriot@gmail.com";
        //     int id= 1;
        //     int stylistId= 1;
        //     Client newClient = new Client(firstName, lastName, phoneNumber, emailAddress, id, stylistId);
        //     List<Client> newList = new List<Client> { newClient };
        //     string name = "Sara";
        //     string description = "Sara is the best";
        //     Stylist newStylist = new Stylist(name, description);
        //     newStylist.GetClients();
        //
        //     //Act
        //     List<Client> result = newStylist.GetClients();
        //
        //     //Assert
        //     CollectionAssert.AreEqual(newList, result);
        // }

    }
}

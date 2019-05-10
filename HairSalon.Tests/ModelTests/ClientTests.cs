using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class ClientTest : IDisposable
    {

        public void Dispose()
        {
          Client.ClearAll();
        }

        [TestMethod]
        public void ClientConstructor_CreatesInstanceOfClient_Client()
        {
          // Arrange
          Client newClient = new Client(1, "Marc", "Davies", "3232866556", "marcdaviesriot@gmail.com");

          // Assert
          Assert.AreEqual(typeof(Client), newClient.GetType());
        }

        [TestMethod]
        public void GetFirstName_ReturnsFirstName_String()
        {
          // Arrange
          int id= 1;
          string firstName = "Marc";
          string lastName = "Davies";
          string phoneNumber = "3232866556";
          string emailAddress = "marcdaviesriot@gmail.com";
          Client newClient = new Client(id, firstName, lastName, phoneNumber, emailAddress);

          // Act
          string result = newClient.GetFirstName();

          // Assert
          Assert.AreEqual(firstName, result);
        }

        [TestMethod]
        public void SetFirstName_SetFirstName_String()
        {
            // Arrange
            int id= 1;
            string firstName = "Marc";
            string lastName = "Davies";
            string phoneNumber = "3232866556";
            string emailAddress = "marcdaviesriot@gmail.com";
            Client newClient = new Client(id, firstName, lastName, phoneNumber, emailAddress);

            //Act
            string updatedFirstName = "Mimi";
            newClient.SetFirstName(updatedFirstName);
            string result = newClient.GetFirstName();

            //Assert
            Assert.AreEqual(updatedFirstName, result);
        }

        [TestMethod]
        public void GetLastName_ReturnsLastName_String()
        {
          // Arrange
          int id= 1;
          string firstName = "Marc";
          string lastName = "Davies";
          string phoneNumber = "3232866556";
          string emailAddress = "marcdaviesriot@gmail.com";
          Client newClient = new Client(id, firstName, lastName, phoneNumber, emailAddress);

          // Act
          string result = newClient.GetLastName();

          // Assert
          Assert.AreEqual(lastName, result);
        }

        [TestMethod]
        public void SetLastName_SetLastName_String()
        {
            // Arrange
            int id= 1;
            string firstName = "Marc";
            string lastName = "Davies";
            string phoneNumber = "3232866556";
            string emailAddress = "marcdaviesriot@gmail.com";
            Client newClient = new Client(id, firstName, lastName, phoneNumber, emailAddress);

            //Act
            string updatedLastName = "Ajili";
            newClient.SetLastName(updatedLastName);
            string result = newClient.GetLastName();

            //Assert
            Assert.AreEqual(updatedLastName, result);
        }

        [TestMethod]
        public void GetPhoneNumber_ReturnsPhoneNumber_String()
        {
            // Arrange
            int id= 1;
            string firstName = "Marc";
            string lastName = "Davies";
            string phoneNumber = "3232866556";
            string emailAddress = "marcdaviesriot@gmail.com";
            Client newClient = new Client(id, firstName, lastName, phoneNumber, emailAddress);

            // Act
            string result = newClient.GetPhoneNumber();

            // Assert
            Assert.AreEqual(phoneNumber, result);
        }

        [TestMethod]
        public void SetPhoneNumber_SetPhoneNumber_String()
        {
            // Arrange
            int id= 1;
            string firstName = "Marc";
            string lastName = "Davies";
            string phoneNumber = "3232866556";
            string emailAddress = "marcdaviesriot@gmail.com";
            Client newClient = new Client(id, firstName, lastName, phoneNumber, emailAddress);

            //Act
            string updatedPhoneNumber = "3232746995";
            newClient.SetPhoneNumber(updatedPhoneNumber);
            string result = newClient.GetPhoneNumber();

            //Assert
            Assert.AreEqual(updatedPhoneNumber, result);
        }

        [TestMethod]
        public void GetEmailAddress_ReturnsEmailAddress_String()
        {
            // Arrange
            int id= 1;
            string firstName = "Marc";
            string lastName = "Davies";
            string phoneNumber = "3232866556";
            string emailAddress = "marcdaviesriot@gmail.com";
            Client newClient = new Client(id, firstName, lastName, phoneNumber, emailAddress);

            // Act
            string result = newClient.GetEmailAddress();

            // Assert
            Assert.AreEqual(emailAddress, result);
        }

        [TestMethod]
        public void SetEmailAddress_SetEmailAddress_String()
        {
            // Arrange
            int id= 1;
            string firstName = "Marc";
            string lastName = "Davies";
            string phoneNumber = "3232866556";
            string emailAddress = "marcdaviesriot@gmail.com";
            Client newClient = new Client(id, firstName, lastName, phoneNumber, emailAddress);

            //Act
            string updatedEmailAddress = "daviesmarc1983@gmail.com";
            newClient.SetEmailAddress(updatedEmailAddress);
            string result = newClient.GetEmailAddress();

            //Assert
            Assert.AreEqual(updatedEmailAddress, result);
        }

        [TestMethod]
        public void GetAll_ReturnsEmptyList_ClientList()
        {
            // Arrange
            List<Client> newList = new List<Client> { };

            // Act
            List<Client> result = Client.GetAll();

            // Assert
            CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
        public void GetAll_ReturnsClients_ClientList()
        {
            //Arrange
            int id1 = 1;
            int id2 = 2;
            string firstName1 = "Marc";
            string firstName2 = "Davies";
            string lastName1 = "Mimi";
            string lastName2 = "Davies";
            string phoneNumber1 = "3232866556";
            string phoneNumber2 = "3232746995";
            string emailAddress1 = "marcdaviesriot@gmail.com";
            string emailAddress2 = "mimimdavies@gmail.com";
            Client newClient1 = new Client(id1, firstName1, lastName1, phoneNumber1, emailAddress1);
            Client newClient2 = new Client(id2, firstName2, lastName2, phoneNumber2, emailAddress2);
            List<Client> newList = new List<Client> { newClient1, newClient2 };

            //Act
            List<Client> result = Client.GetAll();

            //Assert
            CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
        public void GetId_ClientsInstantiateWithAnIdAndGetterReturns_Int()
        {
            //Arrange
            int id = 1;
            string firstName = "Marc";
            string lastName = "Davies";
            string phoneNumber = "3232866556";
            string emailAddress = "marcdaviesriot@gmail.com";
            Client newClient = new Client(id, firstName, lastName, phoneNumber, emailAddress);

            //Act
            int result = newClient.GetId();

            //Assert
            Assert.AreEqual(1, result);
        }
    }
}

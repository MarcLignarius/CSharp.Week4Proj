using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class ClientTest
    {

        [TestMethod]
        public void ClientConstructor_CreatesInstanceOfClient_Client()
        {
          // Arrange
          Client newClient = new Client("Marc", "Davies");

          // Assert
          Assert.AreEqual(typeof(Client), newClient.GetType());
        }

        [TestMethod]
        public void GetFirstName_ReturnsFirstName_String()
        {
          // Arrange
          string firstName = "Marc";
          string lastName = "Davies";
          Client newClient = new Client(firstName, lastName);

          // Act
          string result = newClient.GetFirstName();

          // Assert
          Assert.AreEqual(firstName, result);
        }

        [TestMethod]
        public void GetLastName_ReturnsLastName_String()
        {
          // Arrange
          string firstName = "Marc";
          string lastName = "Davies";
          Client newClient = new Client(firstName, lastName);

          // Act
          string result = newClient.GetLastName();

          // Assert
          Assert.AreEqual(lastName, result);
        }

    }
}

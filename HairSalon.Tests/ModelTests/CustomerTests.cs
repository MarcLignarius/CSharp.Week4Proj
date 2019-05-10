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
          Client newClient = new Client("Marc");

          // Assert
          Assert.AreEqual(typeof(Client), newClient.GetType());
        }

        [TestMethod]
        public void GetFirstName_ReturnsFirstName_String()
        {
          // Arrange
          string firstName = "Marc";
          Client newClient = new Client(firstName);

          // Act
          string result = newClient.GetFirstName();

          // Assert
          Assert.AreEqual(firstName, result);
        }

    }
}

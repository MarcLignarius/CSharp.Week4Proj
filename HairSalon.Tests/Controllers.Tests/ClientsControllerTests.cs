using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class ClientsControllerTest
    {
      [TestMethod]
      public void Index_HasCorrectModelType_ClientList()
      {
          //Arrange
          ClientsController controller = new ClientsController();
          ViewResult indexView = controller.Index() as ViewResult;

          //Act
          var result = indexView.ViewData.Model;

          //Assert
          Assert.IsInstanceOfType(result, typeof(List<Client>));
      }
    }
}

using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class HomeController : Controller
  {

    [Route("/")]
    public ActionResult Index()
    {
        Client firstClient = new Client("Add first name", "Add last name", "Add phone number");
        return View(firstClient);
    }

    [Route("/clients/new")]
    public ActionResult New()
    {
        return View();
    }

    [Route("/clients")]
    public ActionResult Create(string firstName, string lastName, string phoneNumber)
    {
        Client myClient = new Client(firstName, lastName, phoneNumber);
        return View("Index", myClient);
    }

  }
}

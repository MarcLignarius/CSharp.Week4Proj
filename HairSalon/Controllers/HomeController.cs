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

  }
}

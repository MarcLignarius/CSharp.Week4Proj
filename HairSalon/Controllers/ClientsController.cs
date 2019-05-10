using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {

    [HttpGet("/clients")]
    public ActionResult Index()
    {
        List<Client> allClients = Client.GetAll();
        return View(allClients);
    }

    [HttpGet("/clients/new")]
    public ActionResult New()
    {
        return View();
    }

    [HttpPost("/clients")]
    public ActionResult Create(int id, string firstName, string lastName, string phoneNumber, string emailAddress)
    {
        Client myClient = new Client(id, firstName, lastName, phoneNumber, emailAddress);
        return RedirectToAction("Index");
    }

    [HttpPost("/clients/delete")]
    public ActionResult DeleteAllClients()
    {
        Client.ClearAll();
        return View();
    }

  }
}

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

    [HttpGet("/stylists/{stylistId}/clients/{clientId}")]
    public ActionResult Show(int stylistId, int clientId)
    {
      Client client = Client.Find(clientId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist stylist = Stylist.Find(stylistId);
      model.Add("client", client);
      model.Add("stylist", stylist);
      return View(model);
    }

    [HttpGet("/stylists/{stylistId}/clients/new")]
    public ActionResult New(int stylistId)
    {
       Stylist stylist = Stylist.Find(stylistId);
       return View(stylist);
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

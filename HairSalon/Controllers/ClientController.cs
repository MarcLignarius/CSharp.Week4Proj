using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class ClientController : Controller
    {

        [HttpGet("/clients")]
        public ActionResult Index()
        {
            List<Client> allClients = Client.GetAll();
            return View(allClients);
        }

        [HttpPost("/clients")]
        public ActionResult Create(string firstName, string lastName, string phoneNumber, string emailAddress)
        {
            Client newClient = new Client(firstName, lastName, phoneNumber, emailAddress);
            newClient.Save();
            List<Client> allClients = Client.GetAll();
            return View("Index", allClients);
        }

        [HttpGet("/clients/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpGet("/clients/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Client selectedClient = Client.Find(id);
            List<Stylist> clientStylists = selectedClient.GetStylists();
            List<Stylist> allStylists = Stylist.GetAll();
            model.Add("selectedClient", selectedClient);
            model.Add("clientStylists", clientStylists);
            model.Add("allStylists", allStylists);
            return View(model);
        }

        [HttpPost("/clients/{clientId}/stylists/new")]
        public ActionResult AddStylist(int clientId, int stylistId)
        {
            Client client = Client.Find(clientId);
            Stylist stylist = Stylist.Find(stylistId);
            client.AddStylist(stylist);
            return RedirectToAction("Show",  new { id = clientId });
        }

        [HttpPost("/clients/{clientId}/stylists/{stylistId}")]
        public ActionResult Update(int stylistId, int clientId, string newFirstName, string newLastName, string newPhoneNumber, string newEmailAddress)
        {
            Client client = Client.Find(clientId);
            client.Edit(newFirstName, newLastName, newPhoneNumber, newEmailAddress);
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist stylist = Stylist.Find(stylistId);
            model.Add("stylist", stylist);
            model.Add("client", client);
            return View("Show", model);
        }

        [HttpPost("/clients/{clientId}/stylists/{stylistId}/delete")]
        public ActionResult Delete(int stylistId, int clientId)
        {
            Client client = Client.Find(clientId);
            client.Delete();
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist foundStylist = Stylist.Find(stylistId);
            List<Client> stylistClients = foundStylist.GetClients();
            model.Add("clients", stylistClients);
            model.Add("stylist", foundStylist);
            return View(model);
        }

        [HttpGet("/clients/{clientId}/stylists/{stylistId}/edit")]
        public ActionResult Edit(int stylistId, int clientId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist stylist = Stylist.Find(stylistId);
            model.Add("stylist", stylist);
            Client client = Client.Find(clientId);
            model.Add("client", client);
            return View(model);
        }

    }
}

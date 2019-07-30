using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;


namespace HairSalon.Controllers
{
    public class ClientsController : Controller
    {   
        [HttpGet("/stylists/{stylistId}/clients/new")]
        public ActionResult New(int stylistId)
        {
            Stylist stylist = Stylist.Find(stylistId);
            return View(stylist);
        }

        [HttpGet("/stylists/{stylistId}/clients/{clientId}")]
        public ActionResult Show(int stylistId, int clientId)
        {
            Client client = Client.Find(clientId);
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist stylist = Stylist.Find(stylistId);
            model.Add("stylist", stylist);
            model.Add("client", client);
            return View(model);
        }

        [HttpPost("/stylists/{stylistId}/clients/{clientId}/delete")]
        public ActionResult Delete(int stylistId, int clientId)
        {
            Client foundClient = Client.Find(clientId);
            foundClient.DeleteClient();
            return RedirectToAction("Show", "Stylist", new {id = stylistId});
        }

        [HttpGet("/stylists/{stylistId}/clients/{clientId}/edit")]
        public ActionResult Edit(int stylistId, int clientId)
        {
            Client client = Client.Find(clientId);
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist stylist = Stylist.Find(stylistId);
            model.Add("stylist", stylist);
            model.Add("client", client);
            return View(model);
        }

        [HttpPost("/stylists/{stylistId}/clients/{clientId}/edit")]
        public ActionResult Update(int clientId, string newFirstName, string newLastName, string newPhoneNumber, string newEmailAddress)
        {
            Client foundClient = Client.Find(clientId);
            foundClient.Edit(newFirstName, newLastName, newPhoneNumber, newEmailAddress);
            return RedirectToAction("Show", new {id = clientId});
        }
    }
}

using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class StylistController : Controller
    {
        [HttpGet("/stylists")]
        public ActionResult Index()
        {
            List<Stylist> allStylists = Stylist.GetAll();
            return View(allStylists);
        }

        [HttpPost("/stylists")]
        public ActionResult Create(string name, string description)
        {
            Stylist newStylist = new Stylist(name, description);
            newStylist.Save();
            List<Stylist> allStylists = Stylist.GetAll();
            return View("Index", allStylists);
        }

        [HttpGet("/stylists/new")]
        public ActionResult New()
        {
          return View();
        }

        [HttpGet("/stylists/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist selectedStylist = Stylist.Find(id);
            List<Client> stylistClients = selectedStylist.GetClients();
            model.Add("stylist", selectedStylist);
            model.Add("clients", stylistClients);
            return View(model);
        }

        [HttpPost("/stylists/{stylistId}/clients")]
        public ActionResult Create(int stylistId, string firstName, string lastName, string phoneNumber, string emailAddress)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist foundStylist = Stylist.Find(stylistId);
            Client newClient = new Client(firstName, lastName, phoneNumber, emailAddress, stylistId);
            newClient.Save();
            List<Client> stylistClients = foundStylist.GetClients();
            model.Add("clients", stylistClients);
            model.Add("stylist", foundStylist);
            return View("Show", model);
        }

        [HttpPost("/stylists/delete-stylists")]
        public ActionResult DeleteAll()
        {
            Stylist.ClearAll();
            return RedirectToAction("Index");
        }

    }
}

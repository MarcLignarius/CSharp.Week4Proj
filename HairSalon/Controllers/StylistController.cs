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
            List<Client> allClients = Client.GetAll();
            model.Add("stylist", selectedStylist);
            model.Add("stylistClients", stylistClients);
            model.Add("allClients", allClients);
            return View(model);
        }

        [HttpPost("/stylists/{stylist_id}/clients/new")]
        public ActionResult AddClient(int stylist_id, int client_id)
        {
            Stylist stylist = Stylist.Find(stylist_id);
            Client client = Client.Find(client_id);
            stylist.AddClient(client);
            return RedirectToAction("Show", new {id = stylist_id});
        }
    }
}

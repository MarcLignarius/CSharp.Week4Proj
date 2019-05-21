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

        [HttpGet("/stylists/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/stylists")]
        public ActionResult Create(string name, string description)
        {
            Stylist newStylist = new Stylist(name, description);
            newStylist.Save();
            return RedirectToAction("Index");
        }

        [HttpGet("/stylists/{stylistId}")]
        public ActionResult Show(int stylistId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist selectedStylist = Stylist.Find(stylistId);
            List<Specialty> stylistSpecialties = selectedStylist.GetSpecialties();
            List<Specialty> allSpecialties = Specialty.GetAll();
            List<Client> stylistClients = selectedStylist.GetClients();
            model.Add("stylist", selectedStylist);
            model.Add("clients", stylistClients);
            model.Add("specialty", allSpecialties);
            model.Add("stylistSpecialties", stylistSpecialties);
            return View(model);
        }

        [HttpPost("/stylists/{stylistId}/add-specialty")]
        public ActionResult AddSpecialty(int stylistId, int id)
        {
            Stylist foundStylist = Stylist.Find(stylistId);
            foundStylist.AddSpecialty(id);
            return RedirectToAction("Show", new {id = stylistId});
        }

        [HttpPost("/stylists/{stylistId}/delete")]
        public ActionResult Delete(int stylistId)
        {
            Stylist foundStylist = Stylist.Find(stylistId);
            List<Client> stylistClients = foundStylist.GetClients();
            foreach(Client client in stylistClients)
            {
                client.DeleteClient();
            }
            foundStylist.DeleteStylist();
            return RedirectToAction("Index");
        }

        [HttpPost("/stylists/{stylistId}/clients/new")]
        public ActionResult CreateClient(int stylistId, string firstName, string lastName, string phoneNumber, string emailAddress)
        {
            Stylist foundStylist = Stylist.Find(stylistId);
            Client newClient = new Client(firstName, lastName, phoneNumber, emailAddress, stylistId);
            newClient.Save();
            return RedirectToAction("Show", new{id = stylistId});
        }

        [HttpPost("/stylists/delete-stylists")]
        public ActionResult DeleteStylists()
        {
            Stylist.ClearAll();
            return RedirectToAction("Index");
        }

        [HttpPost("/stylists/{stylistId}/delete-clients")]
        public ActionResult DeleteClients(int stylistId)
        {
            Stylist foundStylist = Stylist.Find(stylistId);
            List<Client> stylistClients = foundStylist.GetClients();
            foreach(Client client in stylistClients)
            {
                client.DeleteClient();
            }
            return RedirectToAction("Show", new {id = stylistId});
        }

        [HttpGet("/stylists/{stylistId}/edit")]
        public ActionResult Edit(int stylistId)
        {
            Stylist selectedStylist = Stylist.Find(stylistId);
            return View(selectedStylist);
        }

        [HttpPost("/stylists/{stylistId}/edit")]
        public ActionResult Update(string newName, string newDescription, int stylistId)
        {
            Stylist selectedStylist = Stylist.Find(stylistId);
            selectedStylist.Edit(newName, newDescription);
            return RedirectToAction("Show", new {id = stylistId});
        }
    }
}

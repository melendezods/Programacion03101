using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Universidad.Models;
using Universidad.Utility;

namespace Universidad.Controllers
{
    public class TicketController : Controller
    {


        private readonly IUtility _utility;
        private readonly AppSettings _appSettings;


        public TicketController(IUtility utility, AppSettings appSettings)
        {
            _utility = utility;
            _appSettings = appSettings;
        }
        // GET: TicketController
        public ActionResult Index()
        {
            string user = Request.Cookies["EmailUser"];
            List<Ticket> ticket = JsonConvert.DeserializeObject<List<Ticket>>(_utility.RestClient.Get(_appSettings.url.Ticket));
            List<Luggage> luggage = JsonConvert.DeserializeObject<List<Luggage>>(_utility.RestClient.Get(_appSettings.url.Luggage));
            List<Flight> flight = JsonConvert.DeserializeObject<List<Flight>>(_utility.RestClient.Get(_appSettings.url.Flight));

            List<Country> country = JsonConvert.DeserializeObject<List<Country>>(_utility.RestClient.Get(_appSettings.url.Country));
            flight[0].Country = country;
            ticket[0].Luggages = luggage;
            ticket[0].Flights = flight;

            return View(ticket.FindAll(x => x.IdUser == user));
        }

        // GET: TicketController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TicketController/Create
        public ActionResult Create()
        {
            List<Flight> flight = JsonConvert.DeserializeObject<List<Flight>>(_utility.RestClient.Get(_appSettings.url.Flight));
            List<Luggage> luggage = JsonConvert.DeserializeObject<List<Luggage>>(_utility.RestClient.Get(_appSettings.url.Luggage));
            List<Country> country = JsonConvert.DeserializeObject<List<Country>>(_utility.RestClient.Get(_appSettings.url.Country));
            flight[0].Country = country;
            Ticket ticket = new Ticket()
            {
                Luggages = luggage,
                Flights = flight
            };
            return View(ticket);
        }

        // POST: TicketController/Create
        [HttpPost]
        public ActionResult Create(Ticket ticket)
        {
            try
            {
                ticket.IdUser = Request.Cookies["EmailUser"];
                if (ticket != null)
                {
                    _utility.RestClient.Post(_appSettings.url.Ticket, JsonConvert.SerializeObject(ticket));
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TicketController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TicketController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TicketController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TicketController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

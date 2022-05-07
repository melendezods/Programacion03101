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
    public class FlightController : Controller
    {

        private readonly IUtility _utility;
        private readonly AppSettings _appSettings;


        public FlightController(IUtility utility, AppSettings appSettings)
        {
            _utility = utility;
            _appSettings = appSettings;
        }
        // GET: FlightController
        public ActionResult Index()
        {

            List<Crew> crew = JsonConvert.DeserializeObject<List<Crew>>(_utility.RestClient.Get(_appSettings.url.Crew));
            List<Country> country = JsonConvert.DeserializeObject<List<Country>>(_utility.RestClient.Get(_appSettings.url.Country));
            List<Airplane> airplane = JsonConvert.DeserializeObject<List<Airplane>>(_utility.RestClient.Get(_appSettings.url.Airplane));

            List<Flight> flight = JsonConvert.DeserializeObject<List<Flight>>(_utility.RestClient.Get(_appSettings.url.Flight));

            flight[0].Country = country;
            flight[0].Crew = crew;
            flight[0].Airplanes = airplane;

            return View(flight);
        }

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FlightController/Create
        public ActionResult Create()
        {

            List<Crew> crew = JsonConvert.DeserializeObject<List<Crew>>(_utility.RestClient.Get(_appSettings.url.Crew));
            List<Country> country = JsonConvert.DeserializeObject<List<Country>>(_utility.RestClient.Get(_appSettings.url.Country));
            List<Airplane> airplane = JsonConvert.DeserializeObject<List<Airplane>>(_utility.RestClient.Get(_appSettings.url.Airplane));
            Flight flight = new Flight()
            { 
                Crew = crew,
                Country = country,
                Airplanes = airplane
            };


            return View(flight);
        }

        // POST: FlightController/Create
        [HttpPost]
        public ActionResult Create(Flight flight)
        {
            try
            {

                if (flight != null)
                {
                    JsonConvert.DeserializeObject<Flight>(_utility.RestClient.Post(_appSettings.url.Flight, JsonConvert.SerializeObject(flight)));
                }


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FlightController/Edit/5
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

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FlightController/Delete/5
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

        public ActionResult Search()
        {
            List<Country> country = JsonConvert.DeserializeObject<List<Country>>(_utility.RestClient.Get(_appSettings.url.Country));

            return View(country);
        }

        [HttpPost]
        public ActionResult FlightList(SearchFlight searchFlight)
        {
            SearchFlightResult searchFlightResult = new SearchFlightResult();
            if (searchFlight != null)
            {
                List<Country> country = JsonConvert.DeserializeObject<List<Country>>(_utility.RestClient.Get(_appSettings.url.Country));
                List<Flight> flight = JsonConvert.DeserializeObject<List<Flight>>(_utility.RestClient.Get(_appSettings.url.Flight));

                List<Airplane> airplane = JsonConvert.DeserializeObject<List<Airplane>>(_utility.RestClient.Get(_appSettings.url.Airplane));

                List<Luggage> luggage = JsonConvert.DeserializeObject<List<Luggage>>(_utility.RestClient.Get(_appSettings.url.Luggage));

                List<Flight> flightStart = flight.FindAll(x => Convert.ToDateTime(x.DateFlight).ToString("yyyy/MM/dd") ==
                searchFlight.startDate.ToString("yyyy/MM/dd") && x.IdOriginCountry == searchFlight.IdOriginCountry).ToList();

                List<Flight> flightEnd = flight.FindAll(x => Convert.ToDateTime(x.DateFlight).ToString("yyyy/MM/dd") ==
                searchFlight.endDate.ToString("yyyy/MM/dd") && x.IdOriginCountry == searchFlight.IdDestinationCountry).ToList();


                searchFlightResult = new SearchFlightResult()
                {
                    FlightsSatrt = flightStart,
                    FlightsEnd = flightEnd,
                    SearchData = searchFlight,
                    Countries = country,
                    Luggages = luggage
                };

                return View(searchFlightResult);
            }
            return View(searchFlightResult);
        }

        [HttpPost]
        public ActionResult InvoiceFlight(DataFlight DataFlight)
        {
            SearchFlightResult searchFlightResult = new SearchFlightResult();
            if (DataFlight != null)
            {
                List<Country> country = JsonConvert.DeserializeObject<List<Country>>(_utility.RestClient.Get(_appSettings.url.Country));
                List<Flight> flight = JsonConvert.DeserializeObject<List<Flight>>(_utility.RestClient.Get(_appSettings.url.Flight));

                List<Airplane> airplane = JsonConvert.DeserializeObject<List<Airplane>>(_utility.RestClient.Get(_appSettings.url.Airplane));

                List<Luggage> luggage = JsonConvert.DeserializeObject<List<Luggage>>(_utility.RestClient.Get(_appSettings.url.Luggage));

                List<Flight> flightStart = flight.FindAll(x => x.IdFlight == DataFlight.IdFligStart).ToList();

                List<Flight> flightEnd = flight.FindAll(x => x.IdFlight == DataFlight.IdFligReturn).ToList();


                searchFlightResult = new SearchFlightResult()
                {
                    FlightsSatrt = flightStart,
                    FlightsEnd = flightEnd,                    
                    Countries = country,
                    Luggages = luggage,
                    DataFlight = DataFlight
                };

                return View(searchFlightResult);
            }
            return View(searchFlightResult);
        }
       
    }
}

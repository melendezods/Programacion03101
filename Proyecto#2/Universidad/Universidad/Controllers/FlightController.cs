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

                Set("DataFlight", JsonConvert.SerializeObject(searchFlightResult), 10);

                return View(searchFlightResult);
            }
            return View(searchFlightResult);
        }

        [HttpPost]
        public ActionResult InvoiceFlightFinish(List<Person> people)
        {
            SearchFlightResult searchFlightResult = JsonConvert.DeserializeObject<SearchFlightResult>(Request.Cookies["DataFlight"]);

            if (searchFlightResult != null)
            {

                List<Airplane> airplane = JsonConvert.DeserializeObject<List<Airplane>>(_utility.RestClient.Get(_appSettings.url.Airplane));
                Flight flightStart = searchFlightResult.FlightsSatrt.FirstOrDefault();
                Flight flightEnd = searchFlightResult.FlightsEnd.FirstOrDefault();

            
                string pasajeros = "";

                foreach (var item in people)
                {
                    pasajeros +=
                        "<div>Nombre: " + item.Name + "</div>" +
                        "<div>Apellidos: " + item.LastName + " " + item.Surname + "</div>" +
                        "<div>Identificación: " + item.Identification + "</div>" +
                        "<div>Correo electrónico: " + item.Email + "</div>";
                }
                string total = ((searchFlightResult.DataFlight.Adults + searchFlightResult.DataFlight.Minors) *
               (searchFlightResult.FlightsSatrt.First().PriceEconomical + searchFlightResult.FlightsEnd.First().PriceEconomical +
               searchFlightResult.Luggages.Find(x => x.IdLuggage == searchFlightResult.DataFlight.LuggageStart).Price +
               searchFlightResult.Luggages.Find(x => x.IdLuggage == searchFlightResult.DataFlight.LuggageReturn).Price)).ToString();
                string body = "";
                if (searchFlightResult.DataFlight.IdFligReturn != 0)
                {
                    body += "<div><h1>Detalle de boletos comprados</div>";
                    body += "<div><h1> Vuelo de ida con destino ";
                    body += searchFlightResult.Countries.Find(x => x.IdCountry == searchFlightResult.FlightsSatrt.First().IdOriginCountry).Name;
                    body += " -> ";
                    body += searchFlightResult.Countries.Find(x => x.IdCountry == searchFlightResult.FlightsEnd.First().IdOriginCountry).Name;
                    body += "</h1>";
                    body += "<h1> Vuelo de regreso con destino ";
                    body += searchFlightResult.Countries.Find(x => x.IdCountry == searchFlightResult.FlightsEnd.First().IdDestinationCountry).Name;
                    body += " -> ";
                    body += searchFlightResult.Countries.Find(x => x.IdCountry == searchFlightResult.FlightsSatrt.First().IdOriginCountry).Name;
                    body += "</h1>";
                    body += "<div> Duración vuelo de ida " + searchFlightResult.FlightsSatrt.First().Duration + "</div>";
                    body += "<div> Duración vuelo de regreso " + searchFlightResult.FlightsEnd.First().Duration + "</div>";
                    body += "<div> Vuelos ida directo: ";
                    body +=  searchFlightResult.FlightsSatrt.First().Direct == "1" ? "Si" : "No" + "</div>";
                    body += "<div> Vuelos regreso directo: ";
                    body +=  searchFlightResult.FlightsSatrt.First().Direct == "1" ? "Si" : "No" + "</div>";
                    body += "<div> Avión de ida: " + searchFlightResult.FlightsSatrt.First().Airplane + "</div>";
                    body += "<div> Avión de regreso: " + searchFlightResult.FlightsEnd.First().Airplane + "</div>";
                    body += "<div> Equipaje de ida: ";
                    body += searchFlightResult.DataFlight.LuggageStart != 0 ? searchFlightResult.Luggages.Find(x => x.IdLuggage == searchFlightResult.DataFlight.LuggageStart).Description + " " + searchFlightResult.Luggages.Find(x => x.IdLuggage == searchFlightResult.DataFlight.LuggageStart).MaxKilos + " kg" : "de mano peso máximo 10 kg" + "</div>";
                    body += "<div> Equipaje de regreso: ";
                    body += searchFlightResult.DataFlight.LuggageStart != 0 ? searchFlightResult.Luggages.Find(x => x.IdLuggage == searchFlightResult.DataFlight.LuggageReturn).Description + " " + searchFlightResult.Luggages.Find(x => x.IdLuggage == searchFlightResult.DataFlight.LuggageReturn).MaxKilos + " kg" : "de mano peso máximo 10 kg" + "</div>";
                    body += "<h1> Información de pasajeros </h1>" + "</div>";
                    body += "<div>" + pasajeros + "</div>";
                    body += "<h2>Total factura: $" + total + "</h2></div>";
                }
                else
                {
                    body += "<div><h1>Detalle de boleto comprado</div>";
                    body += "<div><h1> Vuelo de ida con destino ";
                    body += searchFlightResult.Countries.Find(x => x.IdCountry == searchFlightResult.FlightsSatrt.First().IdOriginCountry).Name;
                    body += " -> ";
                    body += searchFlightResult.Countries.Find(x => x.IdCountry == searchFlightResult.FlightsEnd.First().IdOriginCountry).Name;
                    body += "</h1>";                   
                    body += "<div> Duración vuelo de ida " + searchFlightResult.FlightsSatrt.First().Duration + "</div>";
                    body += "<div> Vuelos ida directo: ";
                    body += searchFlightResult.FlightsSatrt.First().Direct == "1" ? "Si" : "No" + "</div>";
                    body += "<div> Avión de ida: " + searchFlightResult.FlightsSatrt.First().Airplane + "</div>";
                    body += "<div> Equipaje de ida: ";
                    body += searchFlightResult.DataFlight.LuggageStart != 0 ? searchFlightResult.Luggages.Find(x => x.IdLuggage == searchFlightResult.DataFlight.LuggageStart).Description + " " + searchFlightResult.Luggages.Find(x => x.IdLuggage == searchFlightResult.DataFlight.LuggageStart).MaxKilos + " kg" : "de mano peso máximo 10 kg" + "</div>";
                    body += "<h1> Información de pasajeros </h1>" + "</div>";
                    body += "<div>" + pasajeros + "</div>";
                    body += "<h2>Total factura: $" + total + "</h2></div>";
                }
                Smtp smtp = new Smtp()
                {
                    Body = body,
                    Subject = "Compra boletos aéreos",
                    Email = people.First().Email
                };
                _utility.RestClient.Post(_appSettings.url.Smtp, JsonConvert.SerializeObject(smtp));

                searchFlightResult.People = people;
                return View(searchFlightResult);
            }
            return View(searchFlightResult);
        }

        public void Set(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();

            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMilliseconds(10);

            Response.Cookies.Append(key, value, option);
        }

    }
}

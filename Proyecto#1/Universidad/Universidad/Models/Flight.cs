using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Universidad.Models
{
    public class Flight
    {
        public int IdFlight { get; set; }
        public string DateFlight { get; set; }
        public string Direct { get; set; }
        public int IdOriginCountry { get; set; }
        public int IdDestinationCountry { get; set; }
        public string Duration { get; set; }
        public int IdCrew { get; set; }
        public double PriceEconomical { get; set; }
        public double PriceFrist { get; set; }
        public string Airplane { get; set; }

        public List<Country> Country { get; set; }
        public List<Airplane> Airplanes { get; set; }
        public List<Crew> Crew { get; set; }
    }


    public class SearchFlight
    {
        public int IdOriginCountry { get; set; }
        public int IdDestinationCountry { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public int Adults { get; set; }

        public int Minors { get; set; }

        public int Baby { get; set; }

        public string RoundFlight { get; set; }

        public string SimpleFlight { get; set; }


    }

    public class SearchFlightResult
    {
       public List<Flight> FlightsSatrt { get; set; }
        public List<Flight> FlightsEnd { get; set; }

        public List<Country> Countries { get; set; }

        public List<Airplane> Airplanes { get; set; }

        public List<Luggage> Luggages { get; set; }

        public SearchFlight SearchData { get; set; }

        public DataFlight DataFlight { get; set; }
    }
}
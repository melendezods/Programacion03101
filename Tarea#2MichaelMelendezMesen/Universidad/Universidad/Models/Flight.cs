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
}

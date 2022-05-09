using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Universidad.Models
{
    public class Ticket
    {
        public int IdTicket { get; set; }
        public string IdUser { get; set; }
        public int IdFlight { get; set; }
        public int IdLuggage { get; set; }
        public string SeatNumber { get; set; }

        public List<Flight> Flights { get; set; }
        public List<Luggage> Luggages { get; set; }

        public Flight Flight { get; set; }
        public Luggage Luggage { get; set; }


    }

    
}

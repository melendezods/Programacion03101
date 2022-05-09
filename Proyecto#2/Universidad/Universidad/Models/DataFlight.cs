using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Universidad.Models
{
    public class DataFlight
    {
        public int IdFligReturn { get; set; }
        public int IdFligStart { get; set; }

        public int Adults { get; set; }

        public int Minors { get; set; }

        public int Baby { get; set; }

        public int LuggageReturn { get; set; }

        public int LuggageStart { get; set; }

        public int PriceIdaEco { get; set; }

        public int PriceVueltaEco { get; set; }

        public int PriceIdaFrist { get; set; }

        public int PriceVueltaFrist { get; set; }
        
    }
}

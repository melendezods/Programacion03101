using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Universidad.Models
{
    public class Luggage
    {
        public int IdLuggage { get; set; }
        public string ShortDes { get; set; }
        public string Description { get; set; }
        public int MaxKilos { get; set; }
        public double Price { get; set; }
    }
}

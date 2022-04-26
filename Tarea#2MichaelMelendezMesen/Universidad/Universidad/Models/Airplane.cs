using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Universidad.Models
{
    public class Airplane
    {
        public int IdAirplane { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TotalRows { get; set; }
        public int TotalSeatingXRow { get; set; }
        public int TotalFirstRows { get; set; }
        public int TotalFirstxFristRow { get; set; }
        public int IdTypeAirplane { get; set; }
        public List<TypeAirplane> typeAirplanes { get; set; }
    }
}

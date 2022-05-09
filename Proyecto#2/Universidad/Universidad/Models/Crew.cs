using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Universidad.Models
{
    public class Crew
    {
        public int IdCrew { get; set; }
        public string Description { get; set; }

        public Person Person { get; set; }

        public CrewPerson PersonCrew { get; set; }

        public List<CrewPerson> crewperson { get; set; }

        public List<Person> person { get; set; }
    }

    public class CrewCreate
    { 
       public string Description { get; set; }

        public List<string> CrewPerson { get; set; }

    }

}

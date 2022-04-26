using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Universidad.Models
{
    public class Person
    {
        public int IdPerson { get; set; }
        public string Identification { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        public int IdGender { get; set; }
        public int IdPosition { get; set; }

        public List<Position> Position { get; set; }
        public List<Gender> Gender { get; set; }

        public Position position { get; set; }
        public Gender gender { get; set; }
    }
}

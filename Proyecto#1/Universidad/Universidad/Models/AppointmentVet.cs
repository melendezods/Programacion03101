using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Universidad.Models
{
    public class AppointmentVet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdAnimal { get; set; }
        public int IdShedule { get; set; }
        public string IdUser { get; set; }
        public int IdSpecialtyVet { get; set; }

        public string date { get; set; }

        public string NameAnimal { get; set; }
        public string DescriptionAnimal { get; set; }
        public int AgeAnimal { get; set; }
        public int IdAnimalType { get; set; }
        public int IdAnimalRaze { get; set; }


        public List<AnimalRaze> animalRazes { get; set; }
        public List<AnimalType> animalTypes { get; set; }
        public List<Schedule> schedules { get; set; }
        public List<SpecialtyVet> specialtyVets { get; set; }

        public List<Animal> animals { get; set; }



    }
}

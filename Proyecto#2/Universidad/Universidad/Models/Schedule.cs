using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Universidad.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int QuantityXhour { get; set; }
        public string Hours { get; set; }
        public int IdSpecialty { get; set; }
    }
}

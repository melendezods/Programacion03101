using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadServicios.Entities.Entities
{
    [Table("COUNTRY")]
    public partial class Country
    {
        public Country()
        {
            FlightIdDestinationCountryNavigation = new HashSet<Flight>();
            FlightIdOriginCountryNavigation = new HashSet<Flight>();
        }

        [Key]
        public int IdCountry { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(300)]
        public string Description { get; set; }

        [InverseProperty(nameof(Flight.IdDestinationCountryNavigation))]
        public virtual ICollection<Flight> FlightIdDestinationCountryNavigation { get; set; }
        [InverseProperty(nameof(Flight.IdOriginCountryNavigation))]
        public virtual ICollection<Flight> FlightIdOriginCountryNavigation { get; set; }
    }
}

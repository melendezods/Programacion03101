using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadServicios.Entities.Entities
{
    [Table("FLIGHT")]
    public partial class Flight
    {
        public Flight()
        {
            Ticket = new HashSet<Ticket>();
        }

        [Key]
        public int IdFlight { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateFlight { get; set; }
        [Required]
        [StringLength(1)]
        public string Direct { get; set; }
        public int IdOriginCountry { get; set; }
        public int IdDestinationCountry { get; set; }
        [Required]
        [StringLength(20)]
        public string Duration { get; set; }
        public int IdCrew { get; set; }
        [Required]
        [StringLength(50)]
        public string Airplane { get; set; }
        [Column(TypeName = "numeric(20, 4)")]
        public decimal PriceEconomical { get; set; }
        [Column(TypeName = "numeric(20, 4)")]
        public decimal PriceFrist { get; set; }

        [ForeignKey(nameof(Airplane))]
        [InverseProperty("Flight")]
        public virtual Airplane AirplaneNavigation { get; set; }
        [ForeignKey(nameof(IdCrew))]
        [InverseProperty(nameof(Crew.Flight))]
        public virtual Crew IdCrewNavigation { get; set; }
        [ForeignKey(nameof(IdDestinationCountry))]
        [InverseProperty(nameof(Country.FlightIdDestinationCountryNavigation))]
        public virtual Country IdDestinationCountryNavigation { get; set; }
        [ForeignKey(nameof(IdOriginCountry))]
        [InverseProperty(nameof(Country.FlightIdOriginCountryNavigation))]
        public virtual Country IdOriginCountryNavigation { get; set; }
        [InverseProperty("IdFlightNavigation")]
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}

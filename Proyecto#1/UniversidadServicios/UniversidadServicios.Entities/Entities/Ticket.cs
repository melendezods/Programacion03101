using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadServicios.Entities.Entities
{
    [Table("TICKET")]
    public partial class Ticket
    {
        [Key]
        public int IdTicket { get; set; }
        [Required]
        [StringLength(150)]
        public string IdUser { get; set; }
        public int IdFlight { get; set; }
        public int IdLuggage { get; set; }
        [Required]
        [StringLength(4)]
        public string SeatNumber { get; set; }

        [ForeignKey(nameof(IdFlight))]
        [InverseProperty(nameof(Flight.Ticket))]
        public virtual Flight IdFlightNavigation { get; set; }
        [ForeignKey(nameof(IdLuggage))]
        [InverseProperty(nameof(Luggage.Ticket))]
        public virtual Luggage IdLuggageNavigation { get; set; }
        [ForeignKey(nameof(IdUser))]
        [InverseProperty(nameof(Users.Ticket))]
        public virtual Users IdUserNavigation { get; set; }
    }
}

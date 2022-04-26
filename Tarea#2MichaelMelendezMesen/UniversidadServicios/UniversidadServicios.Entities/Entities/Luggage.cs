using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadServicios.Entities.Entities
{
    [Table("LUGGAGE")]
    public partial class Luggage
    {
        public Luggage()
        {
            Ticket = new HashSet<Ticket>();
        }

        [Key]
        public int IdLuggage { get; set; }
        [Required]
        [StringLength(50)]
        public string ShortDes { get; set; }
        [StringLength(150)]
        public string Description { get; set; }
        public int MaxKilos { get; set; }
        [Column(TypeName = "numeric(20, 4)")]
        public decimal Price { get; set; }

        [InverseProperty("IdLuggageNavigation")]
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}

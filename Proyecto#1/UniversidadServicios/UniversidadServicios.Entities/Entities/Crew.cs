using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadServicios.Entities.Entities
{
    [Table("CREW")]
    public partial class Crew
    {
        public Crew()
        {
            Flight = new HashSet<Flight>();
        }

        [Key]
        public int IdCrew { get; set; }
        [Required]
        [StringLength(150)]
        public string Description { get; set; }

        [InverseProperty("IdCrewNavigation")]
        public virtual ICollection<Flight> Flight { get; set; }
    }
}

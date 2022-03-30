using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadServicios.Entities.Entities
{
    [Table("AIRPLANE")]
    public partial class Airplane
    {
        public int IdAirplane { get; set; }
        [Key]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public int TotalRows { get; set; }
        [Column("TotalSeatingXRow")]
        public int TotalSeatingXrow { get; set; }
        public int TotalFirstRows { get; set; }
        public int TotalFirstxFristRow { get; set; }
        public int IdTypeAirplane { get; set; }

        [ForeignKey(nameof(IdTypeAirplane))]
        [InverseProperty(nameof(TypeAirplane.Airplane))]
        public virtual TypeAirplane IdTypeAirplaneNavigation { get; set; }
    }
}

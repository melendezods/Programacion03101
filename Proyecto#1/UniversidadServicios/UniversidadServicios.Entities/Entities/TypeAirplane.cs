using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadServicios.Entities.Entities
{
    [Table("TYPE_AIRPLANE")]
    public partial class TypeAirplane
    {
        public TypeAirplane()
        {
            Airplane = new HashSet<Airplane>();
        }

        [Key]
        public int IdTypeAirplane { get; set; }
        [Required]
        [StringLength(50)]
        public string ShortDes { get; set; }
        [StringLength(200)]
        public string Description { get; set; }

        [InverseProperty("IdTypeAirplaneNavigation")]
        public virtual ICollection<Airplane> Airplane { get; set; }
    }
}

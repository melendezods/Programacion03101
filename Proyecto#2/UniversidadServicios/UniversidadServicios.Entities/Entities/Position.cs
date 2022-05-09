using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadServicios.Entities.Entities
{
    [Table("POSITION")]
    public partial class Position
    {
        public Position()
        {
            Person = new HashSet<Person>();
        }

        [Key]
        public int IdPosition { get; set; }
        [Required]
        [Column("Position")]
        [StringLength(50)]
        public string Position1 { get; set; }
        [StringLength(200)]
        public string Description { get; set; }

        [InverseProperty("IdPositionNavigation")]
        public virtual ICollection<Person> Person { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadServicios.Entities.Entities
{
    [Table("GENDER")]
    public partial class Gender
    {
        public Gender()
        {
            Person = new HashSet<Person>();
        }

        [Key]
        public int IdGender { get; set; }
        [Required]
        [Column("Gender")]
        [StringLength(50)]
        public string Gender1 { get; set; }

        [InverseProperty("IdGenderNavigation")]
        public virtual ICollection<Person> Person { get; set; }
    }
}

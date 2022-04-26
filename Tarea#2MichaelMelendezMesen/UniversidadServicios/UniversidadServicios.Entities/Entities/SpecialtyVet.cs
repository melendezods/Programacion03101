using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadServicios.Entities.Entities
{
    [Table("SPECIALTY_VET")]
    public partial class SpecialtyVet
    {
        public SpecialtyVet()
        {
            AppointmentVet = new HashSet<AppointmentVet>();
            Schedule = new HashSet<Schedule>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(300)]
        public string Description { get; set; }

        [InverseProperty("IdSpecialtyVetNavigation")]
        public virtual ICollection<AppointmentVet> AppointmentVet { get; set; }
        [InverseProperty("IdSpecialtyNavigation")]
        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}

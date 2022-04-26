using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadServicios.Entities.Entities
{
    [Table("APPOINTMENT_VET")]
    public partial class AppointmentVet
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int IdAnimal { get; set; }
        public int IdShedule { get; set; }
        [Required]
        [StringLength(150)]
        public string IdUser { get; set; }
        public int IdSpecialtyVet { get; set; }

        [ForeignKey(nameof(IdAnimal))]
        [InverseProperty(nameof(Animal.AppointmentVet))]
        public virtual Animal IdAnimalNavigation { get; set; }
        [ForeignKey(nameof(IdShedule))]
        [InverseProperty(nameof(Schedule.AppointmentVet))]
        public virtual Schedule IdSheduleNavigation { get; set; }
        [ForeignKey(nameof(IdSpecialtyVet))]
        [InverseProperty(nameof(SpecialtyVet.AppointmentVet))]
        public virtual SpecialtyVet IdSpecialtyVetNavigation { get; set; }
        [ForeignKey(nameof(IdUser))]
        [InverseProperty(nameof(Users.AppointmentVet))]
        public virtual Users IdUserNavigation { get; set; }
    }
}

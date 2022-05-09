using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadServicios.Entities.Entities
{
    [Table("SCHEDULE")]
    public partial class Schedule
    {
        public Schedule()
        {
            AppointmentVet = new HashSet<AppointmentVet>();
        }

        [Key]
        public int Id { get; set; }
        [Column(TypeName = "date")]
        public DateTime AppointmentDate { get; set; }
        [Column("QuantityXHour")]
        public int QuantityXhour { get; set; }
        [StringLength(10)]
        public string Hours { get; set; }
        public int IdSpecialty { get; set; }

        [ForeignKey(nameof(IdSpecialty))]
        [InverseProperty(nameof(SpecialtyVet.Schedule))]
        public virtual SpecialtyVet IdSpecialtyNavigation { get; set; }
        [InverseProperty("IdSheduleNavigation")]
        public virtual ICollection<AppointmentVet> AppointmentVet { get; set; }
    }
}

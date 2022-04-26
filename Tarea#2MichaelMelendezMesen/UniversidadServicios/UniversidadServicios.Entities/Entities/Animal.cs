using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadServicios.Entities.Entities
{
    [Table("ANIMAL")]
    public partial class Animal
    {
        public Animal()
        {
            AppointmentVet = new HashSet<AppointmentVet>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(300)]
        public string Description { get; set; }
        public int? Age { get; set; }
        public int IdAnimalType { get; set; }
        public int IdAnimalRaze { get; set; }

        [ForeignKey(nameof(IdAnimalRaze))]
        [InverseProperty(nameof(AnimalRaze.Animal))]
        public virtual AnimalRaze IdAnimalRazeNavigation { get; set; }
        [ForeignKey(nameof(IdAnimalType))]
        [InverseProperty(nameof(AnimalType.Animal))]
        public virtual AnimalType IdAnimalTypeNavigation { get; set; }
        [InverseProperty("IdAnimalNavigation")]
        public virtual ICollection<AppointmentVet> AppointmentVet { get; set; }
    }
}

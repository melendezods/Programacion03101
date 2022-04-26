using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadServicios.Entities.Entities
{
    [Table("ANIMAL_RAZE")]
    public partial class AnimalRaze
    {
        public AnimalRaze()
        {
            Animal = new HashSet<Animal>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(300)]
        public string Description { get; set; }
        public int IdAnimalType { get; set; }

        [ForeignKey(nameof(IdAnimalType))]
        [InverseProperty(nameof(AnimalType.AnimalRaze))]
        public virtual AnimalType IdAnimalTypeNavigation { get; set; }
        [InverseProperty("IdAnimalRazeNavigation")]
        public virtual ICollection<Animal> Animal { get; set; }
    }
}

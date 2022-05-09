using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadServicios.Entities.Entities
{
    [Table("ANIMAL_TYPE")]
    public partial class AnimalType
    {
        public AnimalType()
        {
            Animal = new HashSet<Animal>();
            AnimalRaze = new HashSet<AnimalRaze>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(300)]
        public string Description { get; set; }

        [InverseProperty("IdAnimalTypeNavigation")]
        public virtual ICollection<Animal> Animal { get; set; }
        [InverseProperty("IdAnimalTypeNavigation")]
        public virtual ICollection<AnimalRaze> AnimalRaze { get; set; }
    }
}

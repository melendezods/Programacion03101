using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadServicios.Entities.Entities
{
    [Table("PERSON")]
    public partial class Person
    {
        public int IdPerson { get; set; }
        [Key]
        [StringLength(60)]
        public string Identification { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(60)]
        public string LastName { get; set; }
        [StringLength(60)]
        public string Surname { get; set; }
        [Required]
        [StringLength(200)]
        public string Email { get; set; }
        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }
        public int IdGender { get; set; }
        public int IdPosition { get; set; }

        [ForeignKey(nameof(IdGender))]
        [InverseProperty(nameof(Gender.Person))]
        public virtual Gender IdGenderNavigation { get; set; }
        [ForeignKey(nameof(IdPosition))]
        [InverseProperty(nameof(Position.Person))]
        public virtual Position IdPositionNavigation { get; set; }
    }
}

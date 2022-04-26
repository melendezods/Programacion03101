using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadServicios.Entities.Entities
{
    [Table("USERS")]
    public partial class Users
    {
        public Users()
        {
            AppointmentVet = new HashSet<AppointmentVet>();
            Ticket = new HashSet<Ticket>();
            UsersAuthentication = new HashSet<UsersAuthentication>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Column("lastName")]
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string Surname { get; set; }
        [Key]
        [StringLength(150)]
        public string Email { get; set; }
        [Required]
        [StringLength(500)]
        public string Password { get; set; }

        [InverseProperty("IdUserNavigation")]
        public virtual ICollection<AppointmentVet> AppointmentVet { get; set; }
        [InverseProperty("IdUserNavigation")]
        public virtual ICollection<Ticket> Ticket { get; set; }
        [InverseProperty("EmailNavigation")]
        public virtual ICollection<UsersAuthentication> UsersAuthentication { get; set; }
    }
}

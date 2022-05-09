using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadServicios.Entities.Entities
{
    [Table("USERS_AUTHENTICATION")]
    public partial class UsersAuthentication
    {
        public int Id { get; set; }
        [Key]
        [StringLength(150)]
        public string Email { get; set; }
        [Key]
        [StringLength(400)]
        public string Code { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime AuthDate { get; set; }
        public int ValidMinutes { get; set; }
        public int Status { get; set; }

        [ForeignKey(nameof(Email))]
        [InverseProperty(nameof(Users.UsersAuthentication))]
        public virtual Users EmailNavigation { get; set; }
    }
}

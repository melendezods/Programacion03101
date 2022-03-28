using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadServicios.Entities.Entities
{
    public partial class UsersAuthentication
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }
        public DateTime AuthDate { get; set; }
        public int ValidMinutes { get; set; }
        public int Status { get; set; }

        public virtual Users EmailNavigation { get; set; }
    }
}

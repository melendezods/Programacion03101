﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadServicios.Entities.Entities
{
    [Table("CREWPERSON")]
    public partial class Crewperson
    {
        public int IdCrew { get; set; }
        [Required]
        [StringLength(60)]
        public string IdPerson { get; set; }

        [ForeignKey(nameof(IdCrew))]
        public virtual Crew IdCrewNavigation { get; set; }
        [ForeignKey(nameof(IdPerson))]
        public virtual Person IdPersonNavigation { get; set; }
    }
}

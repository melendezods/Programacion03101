using System;
using System.Collections.Generic;
using System.Text;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Repository.Repository.Crew;

namespace UniversidadServicios.Repository.Sql.Repository.Sql.Crew
{
    public class CrewRepository : Repository<Entities.Entities.Crew>, ICrew
    {
        public CrewRepository(UnedProyectosContext upDbContext) : base(upDbContext)
        {
        }
    }
}

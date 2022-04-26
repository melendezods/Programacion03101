using System;
using System.Collections.Generic;
using System.Text;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Repository.Repository.CrewPerson;

namespace UniversidadServicios.Repository.Sql.Repository.Sql.CrewPerson
{
    public class CrewPersonRepository : Repository<Entities.Entities.Crewperson>, ICrewPerson
    {
        public CrewPersonRepository(UnedProyectosContext upDbContext) : base(upDbContext)
        {
        }
    }
}

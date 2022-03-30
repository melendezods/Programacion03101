using System;
using System.Collections.Generic;
using System.Text;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Repository.Repository.Person;

namespace UniversidadServicios.Repository.Sql.Repository.Sql.Person
{
    public class PersonRepository : Repository<Entities.Entities.Person>, IPerson
    {
        public PersonRepository(UnedProyectosContext upDbContext) : base(upDbContext)
        {
        }
    }
}

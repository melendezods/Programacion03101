using System;
using System.Collections.Generic;
using System.Text;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Repository.Repository.Gender;

namespace UniversidadServicios.Repository.Sql.Repository.Sql.Gender
{
    public class GenderRepository : Repository<Entities.Entities.Gender>, IGender
    {
        public GenderRepository(UnedProyectosContext upDbContext) : base(upDbContext)
        {
        }
    }
}

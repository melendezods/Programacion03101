using System;
using System.Collections.Generic;
using System.Text;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Repository.Repository.Speciality;

namespace UniversidadServicios.Repository.Sql.Repository.Sql.SpecialtyVet
{
   
    public class SpecialtyVetRepository : Repository<Entities.Entities.SpecialtyVet>, ISpecialtyVet
    {
        public SpecialtyVetRepository(UnedProyectosContext upDbContext) : base(upDbContext)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Repository.Repository.TypeAirplane;

namespace UniversidadServicios.Repository.Sql.Repository.Sql.TypeAirplane
{
    public class TypeAirplaneRepository : Repository<Entities.Entities.TypeAirplane>, ITypeAirplane
    {
        public TypeAirplaneRepository(UnedProyectosContext upDbContext) : base(upDbContext)
        {
        }
    }
}

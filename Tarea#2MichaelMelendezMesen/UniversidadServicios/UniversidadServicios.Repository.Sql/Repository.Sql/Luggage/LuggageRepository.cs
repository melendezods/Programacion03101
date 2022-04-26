using System;
using System.Collections.Generic;
using System.Text;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Repository.Repository.Luggage;

namespace UniversidadServicios.Repository.Sql.Repository.Sql.Luggage
{
    public class LuggageRepository : Repository<Entities.Entities.Luggage>, ILuggage
    {
        public LuggageRepository(UnedProyectosContext upDbContext) : base(upDbContext)
        {
        }
    }
}

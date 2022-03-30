using System;
using System.Collections.Generic;
using System.Text;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Repository.Repository.Airplane;

namespace UniversidadServicios.Repository.Sql.Repository.Sql.Airplane
{
    public class AirplaneRepository : Repository<Entities.Entities.Airplane>, IAirplane
    {
        public AirplaneRepository(UnedProyectosContext upDbContext) : base(upDbContext)
        {
        }
    }
}

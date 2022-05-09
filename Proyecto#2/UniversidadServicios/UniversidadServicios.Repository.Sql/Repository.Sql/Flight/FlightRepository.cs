using System;
using System.Collections.Generic;
using System.Text;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Repository.Repository.Flight;

namespace UniversidadServicios.Repository.Sql.Repository.Sql.Flight
{
    public class FlightRepository : Repository<Entities.Entities.Flight>, IFlight
    {
        public FlightRepository(UnedProyectosContext upDbContext) : base(upDbContext)
        {
        }
    }
}

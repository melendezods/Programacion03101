using System;
using System.Collections.Generic;
using System.Text;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Repository.Repository.Position;

namespace UniversidadServicios.Repository.Sql.Repository.Sql.Position
{
    public class PositionRepository : Repository<Entities.Entities.Position>, IPosition
    {
        public PositionRepository(UnedProyectosContext upDbContext) : base(upDbContext)
        {
        }
    }
}

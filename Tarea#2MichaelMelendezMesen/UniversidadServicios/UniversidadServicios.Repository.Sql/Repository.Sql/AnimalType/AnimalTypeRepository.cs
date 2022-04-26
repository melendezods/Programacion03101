using System;
using System.Collections.Generic;
using System.Text;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Repository.Repository.AnimalType;

namespace UniversidadServicios.Repository.Sql.Repository.Sql.AnimalType
{
    public class AnimalTypeRepository : Repository<Entities.Entities.AnimalType>, IAnimalType
    {
        public AnimalTypeRepository(UnedProyectosContext upDbContext) : base(upDbContext)
        {
        }
    }
}

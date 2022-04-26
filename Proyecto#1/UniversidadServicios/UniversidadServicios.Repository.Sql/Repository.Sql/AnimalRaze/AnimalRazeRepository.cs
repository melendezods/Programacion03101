using System;
using System.Collections.Generic;
using System.Text;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Repository.Repository.AnimalRaze;

namespace UniversidadServicios.Repository.Sql.Repository.Sql.AnimalRaze
{
    public class AnimalRazeRepository : Repository<Entities.Entities.AnimalRaze>, IAnimalRaze
    {
        public AnimalRazeRepository(UnedProyectosContext upDbContext) : base(upDbContext)
        {
        }
    }
}

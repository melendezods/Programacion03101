using System;
using System.Collections.Generic;
using System.Text;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Repository.Repository.Animal;

namespace UniversidadServicios.Repository.Sql.Repository.Sql.Animal
{
    public class AnimalRepository : Repository<Entities.Entities.Animal>, IAnimal
    {
        public AnimalRepository(UnedProyectosContext upDbContext) : base(upDbContext)
        {
        }
    }
}

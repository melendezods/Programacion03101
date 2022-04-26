using System;
using System.Collections.Generic;
using System.Text;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Repository.Repository.Country;

namespace UniversidadServicios.Repository.Sql.Repository.Sql.Country
{
    public class CountryRepository : Repository<Entities.Entities.Country>, ICountry
    {
        public CountryRepository(UnedProyectosContext upDbContext) : base(upDbContext)
        {
        }
    }
}

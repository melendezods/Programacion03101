using System;
using System.Collections.Generic;
using System.Text;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Repository.Repository.AppointmentVet;

namespace UniversidadServicios.Repository.Sql.Repository.Sql.AppointmentVet
{
    public class AppointmentVetRepository : Repository<Entities.Entities.AppointmentVet>, IAppointmentVet
    {
        public AppointmentVetRepository(UnedProyectosContext upDbContext) : base(upDbContext)
        {
        }
    }
}

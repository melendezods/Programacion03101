using System;
using System.Collections.Generic;
using System.Text;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Repository.Repository.Shedule;

namespace UniversidadServicios.Repository.Sql.Repository.Sql.Schedule
{
    public class ScheduleRepository : Repository<Entities.Entities.Schedule>, ISchedule
    {
        public ScheduleRepository(UnedProyectosContext upDbContext) : base(upDbContext)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Repository.Repository.Ticket;

namespace UniversidadServicios.Repository.Sql.Repository.Sql.Ticket
{
    public class TicketRepository : Repository<Entities.Entities.Ticket>, ITicket
    {
        public TicketRepository(UnedProyectosContext upDbContext) : base(upDbContext)
        {
        }
    }
}
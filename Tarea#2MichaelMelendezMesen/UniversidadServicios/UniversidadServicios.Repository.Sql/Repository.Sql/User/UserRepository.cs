using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Repository.Repository.User;

namespace UniversidadServicios.Repository.Sql.Repository.Sql.User
{
    public class UserRepository : Repository<Users>, IUserRepository
    {
        public UserRepository(UnedProyectosContext upDbContext) : base(upDbContext)
        {
        }

        public bool Exist(string email)
        {
            return _upDbContext.Users.AsNoTracking().FirstOrDefault(d => d.Email == email) != null;
        }
    }
}

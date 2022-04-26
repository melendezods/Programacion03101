using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Repository.Repository.User.Login;

namespace UniversidadServicios.Repository.Sql.Repository.Sql.Login
{
    public class LoginRepository : Repository<UsersAuthentication>, ILoginRepository
    {
        public LoginRepository(UnedProyectosContext upDbContext) : base(upDbContext)
        {
        }
        public bool Exists(string email, string code)
        {
            return _upDbContext.UsersAuthentication.AsNoTracking().FirstOrDefault(d => d.Email == email && d.Status == 1 && d.Code == code) != null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using UniversidadServicios.Entities.Entities;

namespace UniversidadServicios.Repository.Repository.User.Login
{
    public interface ILoginRepository : IRepository<UsersAuthentication>
    {
        public bool Exists(string email, string code);
    }
}

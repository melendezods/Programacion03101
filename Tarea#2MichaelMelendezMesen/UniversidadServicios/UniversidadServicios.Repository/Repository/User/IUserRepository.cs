using System;
using System.Collections.Generic;
using System.Text;
using UniversidadServicios.Entities.Entities;

namespace UniversidadServicios.Repository.Repository.User
{
    public interface IUserRepository : IRepository<Users>
    {
        public bool Exist(string email);

    }
}

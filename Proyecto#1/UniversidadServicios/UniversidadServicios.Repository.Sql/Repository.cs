using System;
using System.Collections.Generic;
using System.Text;
using UniversidadServicios.Entities.Entities;

namespace UniversidadServicios.Repository.Sql
{
    public class Repository<T> : IRepository<T> where T : class
    {

        public readonly UnedProyectosContext _upDbContext;

        public Repository(UnedProyectosContext upDbContext)
        {
            _upDbContext = upDbContext;
        }
        public int Create(T entity)
        {
            _upDbContext.Add(entity);
            return _upDbContext.SaveChanges();
        }

        public bool Delete(T entity)
        {
            _upDbContext.Remove(entity);
            return _upDbContext.SaveChanges() > 0;
        }

        public T Read(string id)
        {
            return _upDbContext.Set<T>().Find(id);
        }

        public T Read(string id, string id2)
        {
            return _upDbContext.Set<T>().Find(id,id2);
        }

        public IEnumerable<T> ReadAll()
        {
            return _upDbContext.Set<T>();
        }

        public bool Update(T entity)
        {
            _upDbContext.Update(entity);
            return _upDbContext.SaveChanges() > 0;
        }
    }
}

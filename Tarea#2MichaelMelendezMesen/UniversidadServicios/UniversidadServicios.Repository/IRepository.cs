using System;
using System.Collections.Generic;
using System.Text;

namespace UniversidadServicios.Repository
{
    public interface IRepository<T> where T : class
    {
        public int Create(T entity);
        public bool Update(T entity);
        public IEnumerable<T> ReadAll();
        public T Read(string id);
        public T Read(int id);
        public List<T> Read();
        public T Read(string id,string id2);
        public bool Delete(T entity);
    }
}

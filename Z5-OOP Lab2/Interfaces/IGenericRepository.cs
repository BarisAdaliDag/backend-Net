using ekim27_2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekim27_2.Interfaces
{
    public interface IGenericRepository<T> where T: class , IBaseEntity
    {
        T Get(Guid id);
        void Create(T entity);
        void Update(T entity);  
        void Delete(T entity);
        List<T> GetAll();
    }
}

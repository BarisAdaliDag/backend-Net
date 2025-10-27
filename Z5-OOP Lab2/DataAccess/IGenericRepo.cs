using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z5_OOP_Lab2.Entity;


namespace Z5_OOP_Lab2.DataAccess
{
    public interface IGenericRepo<T> where T : class, IBaseEntity, new()
    {

        T Get(Guid id);
        List<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void HardDelete(Guid id);
        void SoftDelete(Guid id);
    }
}

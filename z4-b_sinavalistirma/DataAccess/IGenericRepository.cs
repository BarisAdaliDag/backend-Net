using SinavAlistirma.Models;

namespace SinavAlistirma.DataAccess
{
    public interface IGenericRepository<T> where T : class,IBaseUser,new()
    {
        T Get(Guid id);
        List<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void HardDelete(Guid id);
        void SoftDelete(Guid id);
    }
}
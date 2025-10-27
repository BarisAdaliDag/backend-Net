using SinavAlistirma.Models;

namespace SinavAlistirma.DataAccess
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class, IBaseUser, new()
    {
        static List<T> database = new List<T>();
        public void Create(T entity)
        => database.Add(entity);

        public void HardDelete(Guid id)
        {
            T? t = database.FirstOrDefault(x=>x.Id == id);
           
            if (t != null)
            {
                database.Remove(t);
            }
        }

        public T Get(Guid id)
        {
            T? t = database.FirstOrDefault(x => x.Id == id);
  
            if (t != null)
                return t;

            return new T();
        }

        public List<T> GetAll() => database.Where(x=>x.IsActive).ToList();
        

        public void Update(T entity)
        {
            entity.UpdatedDate = DateTime.Now;
            int index =  database.IndexOf(entity);
            if (index != -1)
                database[index] = entity;
        }

        public void SoftDelete(Guid id)
        {
            T? t = database.FirstOrDefault(x => x.Id == id);
            if (t != null)
            {
                t.IsActive = false;
                t.DeletedDate = DateTime.Now;
            }
        }
    }
}

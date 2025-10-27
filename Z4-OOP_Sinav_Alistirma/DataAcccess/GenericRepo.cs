using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z4_OOP_Sinav_Alistirma.Models;

namespace Z4_OOP_Sinav_Alistirma.DataAcccess
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class,IBaseUser,new()
    {
        static List<T> datebase = new List<T>();
        public void Create(T entity)
        {
            datebase.Add(entity);
        }

        public void HardDelete(Guid id)
        {
            T t = datebase.FirstOrDefault(x => x.Id == id);
            if (t != null)
            {
                datebase.Remove(t);
            }
        }
        public void SoftDelete(Guid id)
        {
            T t = datebase.FirstOrDefault(x => x.Id == id);
            if (t != null)
            {
                t.IsActive = true;
                t.DeletedDate = DateTime.Now;
                datebase.Remove(t);
            }
        }

        public T Get(Guid id)
        {
            T? t  = datebase.FirstOrDefault(x =>x.Id == id);
            if(t != null)
            {
                return t;
            }
            return new T();

        }

        //  public List<T> GetAll() => datebase;
        public List<T> GetAll() => datebase.Where(x => x.IsActive).ToList();

        public void Update(T entity)
        {
         int index =   datebase.IndexOf(entity);
            if(index != -1)
            {
              entity.UplatedDate =DateTime.Now;
                datebase[index]= entity;

            }
        }
    }
}

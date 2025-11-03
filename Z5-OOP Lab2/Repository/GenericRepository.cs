using ekim27_2.Entities;
using ekim27_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ekim27_2.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IBaseEntity, new()
    {
        public static List<T> database = new List<T>();
        public void Create(T entity)
        {
            database.Add(entity);
        }

        public void Delete(T entity)
        {
            database.Remove(entity);
        }

        public T Get(Guid id)
        {
            T t = database.FirstOrDefault(p => p.Id == id);
            if (t != null)
            {
                return t;
            }

            return new T();
        }

        public List<T> GetAll()
        {
            return database;
        }

        public void Update(T entity)
        {
            int index = database.IndexOf(entity);
            if (index != -1)
                entity.UpdatedAt = DateTime.Now;
            database.Insert(index, entity);
        }
    }
}

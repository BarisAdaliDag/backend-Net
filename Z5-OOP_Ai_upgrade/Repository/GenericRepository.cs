using ekim27_2.Entities;
using ekim27_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ekim27_2.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IBaseUser, new()
    {
        private static readonly List<T> items = new();

        public void Create(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (items.Any(x => x.Id == entity.Id))
                throw new InvalidOperationException($"Bu ID zaten mevcut: {entity.Id}");

            entity.UpdatedDate = DateTime.Now;
            items.Add(entity);
        }

        public void Delete(Guid id)
        {
            var entity = Get(id);
            if (entity != null)
                items.Remove(entity);
        }

        public T? Get(Guid id)
        {
            if (id == Guid.Empty)
                return null;

            return items.FirstOrDefault(x => x.Id == id);
        }

        public List<T> GetAll()
        {
            // Sadece aktif olanları getir
            return items.Where(x => x.IsActive).ToList();
        }

        public void SoftDelete(Guid id)
        {
            var entity = Get(id);
            if (entity == null)
                throw new KeyNotFoundException($"ID bulunamadı: {id}");

            entity.IsActive = false;
            entity.DeletedDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;
        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            var existing = Get(entity.Id);
            if (existing == null)
                throw new KeyNotFoundException($"Güncellenecek veri bulunamadı: {entity.Id}");

            entity.UpdatedDate = DateTime.Now;
            int index = items.IndexOf(existing);
            items[index] = entity;
        }
    }
}

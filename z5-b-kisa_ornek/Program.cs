using System;
using System.Collections.Generic;
using System.Linq;

namespace z5_b_kisa_ornek
{
  

    // -----------------------
    // 1. Temel Interface ve Class
    // -----------------------
    public interface IBaseEntity
    {
        Guid Id { get; }
        DateTime CreatedDate { get; }
        DateTime UpdatedAt { get; set; }
    }

    public abstract class BaseEntity : IBaseEntity
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTime CreatedDate { get; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

    // -----------------------
    // 2. Generic Repository Interface
    // -----------------------
    public interface IGenericRepository<T> where T : class, IBaseEntity
    {
        T Get(Guid id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }

    // -----------------------
    // 3. Generic Repository Implementasyonu
    // -----------------------
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IBaseEntity, new()
    {
        protected static readonly List<T> database = new(); // protected: alt sınıflar erişebilsin

        public void Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            database.Add(entity);
        }

        public void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            database.Remove(entity);
        }

        public T Get(Guid id)
        {
            return database.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return database.AsReadOnly();
        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            var index = database.FindIndex(e => e.Id == entity.Id);
            if (index != -1)
            {
                entity.UpdatedAt = DateTime.UtcNow;
                database[index] = entity;
            }
        }
    }

    // -----------------------
    // 4. Member Entity
    // -----------------------
    public class Member : BaseEntity
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"Id: {Id}, Username: {Username}, Email: {Email}, Created: {CreatedDate:yyyy-MM-dd HH:mm}";
        }
    }

    // -----------------------
    // 5. Özel Repository Interface
    // -----------------------
    public interface IMemberRepository : IGenericRepository<Member>
    {
        Member GetByUsername(string username);
    }

    // -----------------------
    // 6. Özel Repository Implementasyonu
    // -----------------------
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        public Member GetByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return null;

            return database.FirstOrDefault(m => m.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }
    }

    // -----------------------
    // 7. Test / Kullanım (Main)
    // -----------------------
    public class Program
    {
        public static void Main()
        {
            IMemberRepository memberRepo = new MemberRepository();

            // Üye ekle
            var member1 = new Member { Username = "ahmet", Email = "ahmet@example.com" };
            var member2 = new Member { Username = "zeynep", Email = "zeynep@example.com" };

            memberRepo.Add(member1);
            memberRepo.Add(member2);

            Console.WriteLine("Tüm Üyeler:");
            foreach (var m in memberRepo.GetAll())
            {
                Console.WriteLine(m);
            }

            // Username ile bul
            var found = memberRepo.GetByUsername("ahmet");
            Console.WriteLine("\n'arhmet' bulundu: " + (found != null ? found.ToString() : "Bulunamadı"));

            // Güncelle
            if (found != null)
            {
                found.Email = "ahmet.yeni@example.com";
                memberRepo.Update(found);
            }

            Console.WriteLine("\nGüncellendikten sonra:");
            Console.WriteLine(memberRepo.Get(found.Id));

            // Büyük/küçük harf duyarsız test
            Console.WriteLine("\n'AHMET' ile arama: " +
                (memberRepo.GetByUsername("AHMET")?.Username ?? "Bulunamadı"));
        }
    }
}

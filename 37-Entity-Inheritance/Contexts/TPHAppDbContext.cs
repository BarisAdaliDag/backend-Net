using _37_Entity_Inheritance.Models;
using Microsoft.EntityFrameworkCore;

namespace _37_Entity_Inheritance.Contexts
{
    public class TPHAppDbContext : DbContext
    {
        //TPH Table Per Hierarchy: Bu strateji vertabanı tasarımında ilişki yansıtan tek bir tablo oluşturur. Hangi nesnenin hangi tür olduğunu belirtmek için bir Discriminator (ayırıcı) kolunu ekler.

        //Avantajları
        //Basit yapı, performans yüksek (join yok)
        //Dezavantajları
        //Boş sutunlar, Tablo büyümesi, normalizasyona aykırı.

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Manager> Managers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CodeFirst3;Integrated Security=True;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasDiscriminator<string>("EmpType")
                .HasValue<Manager>("Müdür")
                .HasValue<Developer>("Geliştirici");
        }
    }
}

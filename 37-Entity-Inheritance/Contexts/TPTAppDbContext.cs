using _37_Entity_Inheritance.Models;
using Microsoft.EntityFrameworkCore;

namespace _37_Entity_Inheritance.Contexts
{
    public class TPTAppDbContext : DbContext
    {
        //TPT Table Per Type: Her sınıf için ayrı bir tablo
        //Alt sınıflar, base sınıf ile ilişkilendirilir (1-1). Veri çekerken birleştirilir (join)
        //Normalizasyonu yüksek, gereksiz sütun yok,
        //Dezavantajı join
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
                .ToTable("Employees");

            modelBuilder.Entity<Developer>()
                .ToTable("Developers")
                .HasBaseType<Employee>();

            modelBuilder.Entity<Manager>()
                .ToTable("Managers")
                .HasBaseType<Employee>();
                
        }
    }
}

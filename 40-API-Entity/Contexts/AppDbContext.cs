using _40_API_Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace _40_API_Entity.Contexts
{
    public class AppDbContext:DbContext
        
    {
        public AppDbContext(DbContextOptions options) : base(options) { }




        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().Property(p=>p.Name).HasMaxLength(50);

            modelBuilder.Entity<Product>().Property(p => p.Description).HasMaxLength(1000);
            modelBuilder.Entity<Product>().Property(p => p.RowVersion).IsRowVersion();

            modelBuilder.Entity<Product>().HasIndex(p => new { p.Name, p.IsDeleted });
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.Entity<Category>().Property(p => p.Name).HasMaxLength(150);
            

        }
    }
}

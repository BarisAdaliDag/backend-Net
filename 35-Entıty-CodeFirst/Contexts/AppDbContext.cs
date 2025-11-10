using _35_Entity_CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace _35_Entity_CodeFirst.Contexts
{
    //Veritabanı ile uygulama arasında bir köprü görevi görür. Tüm veri operasyonları, soruglar, crud işlemleri, ayalar, vb. dbcontext üzerinden gerçekleştirlir.
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Tag> Tag { get; set; }
        //public DbSet<ProductTag> ProductTag { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CodeFirst1;Integrated Security=True;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .ToTable("TblKategori") //Tablonun adını değiştirme.
                .HasKey(x => x.Id); //PrimaryKey

            modelBuilder.Entity<Product>()
                .HasIndex(x => x.Name) //Unique Key
                .IsUnique();

            modelBuilder.Entity<Product>()
                .Ignore(x => x.Deneme); //Deneme sqlde olmaz.

            modelBuilder.Entity<Product>()
                .HasData(new Product() { Id = 1, Name = "Kalem", Price = 300, CategoryId = 2 }); //Default data oluşturma.

            modelBuilder.Entity<Product>()
                .Property(x => x.Name) //Sütün seçimi
                .HasColumnName("UrunAdi") //Sütun adı
                .HasColumnType("nvarchar(50)") //Sütun tipi
                .HasColumnOrder(3) //Sütun sıralamsı
                .HasDefaultValue("Product-1") //Default değer
                .HasDefaultValueSql("GETDATE()") //Sqlde varsayılan değer
                .IsRequired(false) //Null geçilebilir
                .HasMaxLength(50) //Uzunluk.
                .HasComputedColumnSql("[FirstName]" + ' ' + "[LastName]"); //Birleştirme

            modelBuilder.Entity<Product>()
                .Property(x => x.Price)
                .HasColumnType("decimal(18,2)")
                .HasPrecision(18, 2); //Ondalık değer.
                
                
        }
    }
}

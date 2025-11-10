using _35_Entity_CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace _35_Entity_CodeFirst.Configs
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Product
            builder
                .Property(p => p.Name)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder
                .Property(p => p.Price)
                .HasPrecision(18, 2)
                .IsRequired();

            builder
                .HasOne(p => p.ProductDetail)
                .WithOne(pd => pd.Product)
                .HasForeignKey<ProductDetail>(pd => pd.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

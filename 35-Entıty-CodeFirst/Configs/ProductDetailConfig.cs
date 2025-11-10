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
    public class ProductDetailConfig : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {

            //One-to-one
            builder
                .HasKey(pd => pd.ProductId);



            builder
                .Property(pd => pd.Description)
                .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder
                .Property(pd => pd.Color)
                .IsRequired(false);
        }
    }
}

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
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            //Customer
            builder
                .Property(c => c.Email)
                .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder
                .HasIndex(c => c.Email)
            .IsUnique();

            builder
                .Property(c => c.FirstName)
                .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder
                .Property(c => c.LastName)
                .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder
                .Ignore(c => c.FullName);

            builder
                .Property(c => c.Phone)
                .HasColumnType("char(10)")
                .IsRequired(false);

            builder
                .Property(c => c.BirthDate)
                .IsRequired(false)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}

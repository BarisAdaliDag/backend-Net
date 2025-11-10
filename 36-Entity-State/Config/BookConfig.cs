using _36_Entity_State.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _36_Entity_State.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { Id=1, Title="Suç ve Ceza", AuthorId=2 },
                new Book { Id=2, Title="Karamazov Kardeşler", AuthorId=2 },
                new Book { Id=3, Title="Kumarbaz", AuthorId=2 });

            builder.Property(x => x.Title)
                .IsRequired()
                .HasColumnType("nvarchar(50)");
        }
    }
}

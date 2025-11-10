using _37_Entity_Inheritance.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _37_Entity_Inheritance.Contexts
{
    public class AppDbContext : DbContext
    {


        public DbSet<Developer> Developers { get; set; }
        public DbSet<Manager> Managers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CodeFirst3;Integrated Security=True;Encrypt=False");
        }
    }
}

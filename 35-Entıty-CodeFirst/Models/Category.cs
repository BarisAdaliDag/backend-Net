using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _35_Entity_CodeFirst.Models
{
    public class Category
    {
        public Category()
        {
            
        }
        public Category(string name)
        {
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation Property
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}

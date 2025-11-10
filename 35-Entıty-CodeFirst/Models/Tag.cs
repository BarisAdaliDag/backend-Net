using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _35_Entity_CodeFirst.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Title { get; set; }

        //public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();
    }
}

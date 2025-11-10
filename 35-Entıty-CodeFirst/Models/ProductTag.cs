using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _35_Entity_CodeFirst.Models
{
    public class ProductTag
    {
        public int ProductsId { get; set; }
        public int TagsId { get; set; }
        public Tag tag { get; set; }
        public Product product { get; set; }
    }
}

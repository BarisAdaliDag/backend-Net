using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _35_Entity_CodeFirst.Models
{
    public class ProductDetail
    {
 
        public string Description { get; set; }
        public string? Color { get; set; }
        public int ProductId { get; set; }

        //Navigation Prop
        public Product Product { get; set; }
    }
}

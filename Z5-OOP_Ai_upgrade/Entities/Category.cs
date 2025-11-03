using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekim27_2.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} Name: {Name}";
        }
    }
}

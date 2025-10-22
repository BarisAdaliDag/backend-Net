using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_Struct
{
    internal class Product
    {
        private static int id = 0;

        public Product(string name, Currency price)
        {
            Name = name;
            Price = price;
            id++;
        }

        public int Id => id;
        public string Name { get;private  set; }
        public Currency Price { get;private set; }
    }
}

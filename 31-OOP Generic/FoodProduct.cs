using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31_OOP_Generic
{
    internal class FoodProduct : Product
    {
        public FoodProduct(string name, decimal price, int quality) : base(name, price, quality)
        {
        }
    }
}

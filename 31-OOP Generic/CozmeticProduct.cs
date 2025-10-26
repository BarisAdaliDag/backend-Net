using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31_OOP_Generic
{
    public class CozmeticProduct : Product
    {
        public CozmeticProduct(string name, decimal price, int quantity) : base(name, price, quantity)
        {
        }
    }
}

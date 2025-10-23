using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31_OOP_Generic
{
    public class ElectronicProduct : Product
    {
        public int WarrantPeriod { get; set; }
        public ElectronicProduct(string name, decimal price, int quality, int warrantPeriod) : base(name, price, quality)
        {
            WarrantPeriod = warrantPeriod;
        }

        public override string ToString()
        {
            return base.ToString() + $" Warrent Period {WarrantPeriod}";
        }

      ///...
    }
}

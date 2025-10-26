using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28_Interface.BadExamples
{
    public class SqlDatabase
    {
        public void Create(string name, decimal price, int stok)
        {
            Console.WriteLine($"Ürün başarılı bir şekilde SQL database kayıt edildi. {name} - {price} - {stok}");
        }

        public void Update()
        {
            Console.WriteLine("Ürün başaılır bir şekilde SQL de güncellendi.");
        }
    }
}

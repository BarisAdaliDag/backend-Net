using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28_Interface.GoodExamples
{
    public class SqlDatabase : IDatabase
    {
        public void Create(string name, decimal price, int stock)
        {
            Console.WriteLine("Sql ile eklendi");
        }

        public void Delete(int id)
        {
            Console.WriteLine("Sql ile silindi");
        }
    }
}

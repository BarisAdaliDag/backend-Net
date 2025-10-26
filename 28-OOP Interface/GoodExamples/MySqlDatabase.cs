using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28_Interface.GoodExamples
{
    public class MySqlDatabase : IDatabase
    {
        public void Create(string name, decimal price, int stock)
        {
            //
            Console.WriteLine("My sql ile eklendi");
        }

        public void Delete(int id)
        {
            Console.WriteLine("Mysqli ile silindi");
        }
    }
}

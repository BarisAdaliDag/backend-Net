using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31_OOP_Generic
{
    public class InventoryManagment<T> : IInvertoryManagment<T> where T : Product
    {
        private List<T> produts = new List<T>();
        public void Add(T item)
        {
            produts.Add(item);
            Console.WriteLine($"{item.Name} added to inventory");
        }

        public void Decrease(T item, int amount)
        {
            item.DecreseQuality(amount);

        }

        public List<T> GetAll()
        {
            return produts;
        }

        public void Increase(T item, int amount)
        {
           item.IncrementQuality(amount);
        }

        public void Remove(T item)
        {
            produts.Remove(item);
            Console.WriteLine($"{item.Name} removed from inventory");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31_OOP_Generic
{
    public class InventoryManagement<T> : IInventoryManagement<T> where T : Product
    {
        private List<T> products = new List<T>();

        public void Add(T item)
        {
            products.Add(item);
            Console.WriteLine($"{item.Name} added to inventory.");
        }

        public void Decrease(T item, int amount)
        {
            item.DecreaseQuantity(amount);
        }

        public List<T> GetAll()
        {
            return products;
        }

        public void Increase(T item, int amount)
        {
            item.IncreaseQuantity(amount);
        }

        public void Remove(T item)
        {
            products.Remove(item);
            Console.WriteLine($"{item.Name} removed from inventory.");
        }
    }
}

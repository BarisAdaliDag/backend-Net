using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31_OOP_Generic
{
    public interface IInventoryManagement<T> where T : Product
    {
        void Add(T item);
        void Remove(T item);
        List<T> GetAll();
        void Decrease(T item, int amount);
        void Increase(T item, int amount);
    }
}

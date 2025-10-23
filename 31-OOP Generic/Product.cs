using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31_OOP_Generic
{
    public abstract class Product
    {
        public Product(string name, decimal price, int quality)
        {
            Name = name;
            Price = price;
            Quantity = quality;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"Product Name: {Name} Price {Price:C}, Quanity { Quantity}";
        }
        public virtual void IncrementQuality(int amount)
        {
            Quantity += amount;
            Console.WriteLine($"Quantity uptated {Quantity} ");
        }
        public virtual void DecreseQuality(int amount)
        {
            Quantity -= amount;
            Console.WriteLine($"Quantity uptated {Quantity} ");
        }

    }
}

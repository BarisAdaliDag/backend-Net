using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_OOP_Class_Lab
{
    public class Product
    {
        private double _price;//Encapsulation
        public string Name { get; private set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public Product(string name, double price, string category)
        {
            Name = name;
            Price = price;
            Category = category;
        }



        public double Price { get => _price;

            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Fiyat Negatif Olamaz");

                    
                }
                _price = value;
            } }

        public string Category { get; set; }

        public string DisplayInfo()
        {
            return $"Urum : {Name} | Kategori | Fiyat : {Price:C2}";//C2 para birimi
        }


    }

   
}
//field
//constractor
//properties
//method
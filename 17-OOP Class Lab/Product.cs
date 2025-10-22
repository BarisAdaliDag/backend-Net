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

        public Product(double price, string name)
        {
            Price = price;
            Name = name;
          
         
        }
        public Product(double price, string name,string category)
        {
            Price = price;
            Name = name;
            Category = category;


        }

        public string Name { get;  private set; }

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

    internal class Order
    {
        private ICollection<Product> _products;

        public Order(int orderId)
        {
            OrderId = orderId;
            OrderDate= DateTime.Now;
            _products = new HashSet<Product>();
        }

        public int OrderId { get;private set; }
        public DateTime OrderDate { get;private set; }
        public IReadOnlyList<Product> Products => _products.ToList().AsReadOnly();

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }
        public void RemoveProduct(Product product)
        {
            _products.Remove(product);
        }

        public String DisplayOrderSummary()
        {
            string baslik = $"Siparis no:{OrderId}, | Tarih: {OrderDate} \n Urun listesi \n";
            foreach (var item in _products)
            {
                baslik += item.DisplayInfo() + "\n"; 
            }
            return baslik;
        }

    }
}
//field
//constractor
//properties
//method
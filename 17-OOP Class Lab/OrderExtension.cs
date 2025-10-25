using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_OOP_Class_Lab
{
    public static class OrderExtension
    {
        public static string GetFormattedTotal(this Order order)
        {
            return $"{order.CalculateTotal():C2} TL";
        }

        public static Product GetMostExpensiveProduct(this Order order) 
        { 
            return order.Products.OrderByDescending(p => p.Price).FirstOrDefault();
        }

        /// <summary>
        /// Belirli bir oranda indirim uygular.
        /// </summary>
        /// <param name="percent">İndirim uygulanacak oran 1-100 arasında</param>
        /// <returns>İndirim fiyatı geri döndürür.</returns>
        /// <exception cref="ArgumentException">Eğer eksik yada fazla değer girilirse exception fırlatır.</exception>
        public static void ApplyDiscount(this Order order, double percent) 
        {
            if (percent < 0 || percent > 100)
                throw new ArgumentException("Indirim yüzdesi 0 ile 100 arasında olamalıdır!");

            //Reflection 
            foreach (var product in order.Products)
            {
                typeof(Product)
                    .GetProperty("Price")
                    ?.SetValue(product, product.Price * (1 - percent / 100));
            }

            Console.WriteLine($"Yüzde {percent} indirim uygulandı.");
            //return order.CalculateTotal() * (100 - percent) / 100;
        }
    }
}

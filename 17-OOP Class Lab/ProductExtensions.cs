using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace _17_OOP_Class_Lab
//{
//    public static class ProductExtensions
//    {
//        public static string ChangeNumberToMoney(this List<Product> products) {
//            double sumMoney = 0;
//            products.ForEach(p =>
//            {
//                sumMoney += p.Price;
//            });

            
//            return sumMoney.ToString("C");
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="products"></param>
//        /// <returns></returns>
//        public static string MostExpensiveItem (this List<Product> products)
//        {
//            Product mostExpensiveProduct = products[0];

//            for(int i = 0; i< products.Count; i++)
//            {
//                if(mostExpensiveProduct.Price < products[i].Price) {
//                mostExpensiveProduct = products[i];
//                }

//            }
//            return  $"En pahali urun {mostExpensiveProduct.Name} fiyat :"+     mostExpensiveProduct.Price.ToString("C");
//        }

//        //public static string DiscountItem(this Product product, this Product product1)
//        //{
//        //    double discountMoney = 0;



//        //}

//    }
//}

using _38_Entity_LoadingType.Models;
using Microsoft.EntityFrameworkCore;

namespace _38_Entity_LoadingType
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDbContext context = new AppDbContext();

            #region LazyLoading
            //var product = context.Products.Find(2);
            //Console.WriteLine($"Id: {product.Id} Name: {product.Name} Price: {product.Price} Kategori: {product.Category.Name}");

            //Console.WriteLine("\nTüm Productlar");
            //var products = context.Products.ToList();
            //foreach (var item in products)
            //{
            //    Console.WriteLine($"Id: {item.Id} Name: {item.Name} Price: {item.Price} Kategori: {item.Category.Name}");
            //}
            #endregion

            #region EagerLoading
            //Console.WriteLine("Eager Loading");

            //var result = context.Products.Include(p => p.Category);

            //foreach (var item in result)
            //{
            //    Console.WriteLine($"Id: {item.Id} Name: {item.Name} Price: {item.Price} Kategori: {item.Category.Name}");
            //}
            #endregion

            #region ExplicitLoading
            Console.WriteLine("Explicit Loading");

            var category = context.Categories.FirstOrDefault(x => x.Id == 2);
            context.Entry(category).Collection(c => c.Products).Load();

            var product = context.Products.FirstOrDefault(x => x.Id == 2);
            context.Entry(product).Reference(p => p.Category).Load();

            #endregion
        }
    }
}

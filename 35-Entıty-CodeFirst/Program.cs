using _35_Entity_CodeFirst.Contexts;
using _35_Entity_CodeFirst.Models;

namespace _35_Entity_CodeFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (AppDbContext context = new AppDbContext())
            {
                #region Add
                //var cat1 = new Category("Kalemler");
                //context.Categories.Add(cat1);

                //var cat2 = new Category("Kitaplar")
                //{
                //    Products = new List<Product>() 
                //    { 
                //        new Product("Kitap-1", 350),
                //        new Product("Kitap-2", 300),
                //        new Product("Kitap-3", 325)
                //    }
                //};
                //context.Categories.Add(cat2);

                //var product1 = new Product("Kalem-1", 50, 1);
                //context.Products.Add(product1);

                //var cat3 = context.Categories.Find(1);
                //var product2 = new Product("Kalem-2", 35, cat3);
                //context.Products.Add(product2);
                #endregion

                #region Update
                //var product1 = context.Products.Find(6);
                //product1.Price = 33;
                //context.Update(product1);
                #endregion

                #region Remove
                //var product1 = context.Products.Find(6);
                //var cat1 = context.Categories.Find(1);
                //var product1 = new Product { Id = 5, Name = "Kalem-1", Price = 50, CategoryId = 1, Category = cat1 };
                //var product2 = new Product { Id = 3 };
                //context.Products.Remove(product2);
                //context.Categories.Remove(new Category { Id = 3 });
                #endregion

                #region Relationship
                //context.Tag.AddRange(
                //    new Tag { Title="Yeni" },
                //    new Tag { Title="Kapmanya" },
                //    new Tag { Title="Indırim" });

                //var produc1 = new Product("Kitap-4", 400, 4)
                //{
                //    Tags = context.Tag.Where(x => x.Title == "Yeni" || x.Title == "Kapmanya").ToList()
                //};
                //context.Products.Add(produc1);

                //var tag2 = context.Tag.FirstOrDefault(x => x.Title == "Yeni");
                //var product2 = context.Products.FirstOrDefault(x => x.Name == "Kalem-1");

                //product2.Tags.Add(tag2);

                //foreach (var item in context.ProductTag.ToList())
                //{
                //    Console.WriteLine(item.TagsId + " - " + item.ProductsId);
                //}

                #endregion

                #region IQueryableAndIEnumerable

                //var products = context.Products
                //    .Where(x => x.Id > 0)
                //    .AsEnumerable()
                //    .Select(x => new { Adi = x.Name, Fiyat = x.Price });

                //foreach (var item in products)
                //{
                    
                //}

                #endregion

                Console.WriteLine(context.SaveChanges()>0?"Veritabanı operasyonu başarılı":"Veritabanı operasyonu başarısız");


                Console.ReadLine();
            };

        }
    }
}

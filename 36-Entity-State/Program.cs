using _36_Entity_State.Contexts;
using _36_Entity_State.Models;
using Microsoft.EntityFrameworkCore;

namespace _36_Entity_State
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Entity State: EF Core'un bir entity'nin durumunu izlemek için kullandığı bir mekanızmadır. EntityState olarak isimlendirilen bir enum üzerinden çalışır. Bu enum entity'in dbcontext içinde nasıl ele alanacağını tanımlar. Eklenecek mi? Güncellenecek mi? Silinecek mi? gibi...

            /*
             * Detached => Bağlantısız (Henüz veritabanına işlenmemiş veri)
             * Unchanged => Değişmemiş (Varlık veritabanına tanımlı ama işlem yapılmamış)
             * Modified => Değiştirilmiş/Güncelleştirilmiş
             * Deleted => Silinmiş
             * Added = Eklenmiş
             */

            using AppDbContext context = new AppDbContext();
            //context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            //var author = new Author { FirstName = "Perami", LastName = "Sefa" };
            //var author = context.Authors.FirstOrDefault(x => x.FirstName == "William");
            //Console.WriteLine(context.Entry(author).State);

            //author.FirstName = "PERAMİ2";
            //Console.WriteLine(context.Entry(author).State);

            //context.Add(author);
            //context.Entry(author).State = EntityState.Deleted;
            //Console.WriteLine(context.Entry(author).State);

            //author.LastName = "SEFA";
            //Console.WriteLine(context.Entry(author).State);

            //context.Entry(author).State = EntityState.Detached;
            //Console.WriteLine(context.Entry(author).State);

            //context.SaveChanges();

            //Console.WriteLine(context.Entry(author).State);

            /* Added ve Updated -> Unchanged
             * Deleted -> DbContext'ten kaldırır. Detached
             */

            //var books = context.Books.AsNoTracking().ToList();
            //foreach (var item in books)
            //{
            //    if (item.Id == 2)
            //    {
            //        context.Attach(item); //Explicit olarak takip başlatılır.
            //        Console.WriteLine(context.Entry(item).State);
            //        item.Title = "Deneme";
            //        //context.Update(item);
            //    } 
            //    Console.WriteLine(context.Entry(item).State);
            //}

            //var books2 = context.Books.ToList();
            //foreach (var item in books2)
            //{
            //    Console.WriteLine(context.Entry(item).State);
            //}

            //Native Sql Yazma

            Console.WriteLine("Sql Native");
            var result = context.Books.FromSqlRaw("SELECT * FROM Books WHERE Id >= {0}",2);

            var resultA = context.Books.FromSqlInterpolated($"SELECT * FROM Books WHERE Id={2}");

            foreach (var item in result)
            {
                Console.WriteLine(item.Title);
                Console.WriteLine(context.Entry(item).State);
            }

            var result2 = context.Database.ExecuteSqlRaw("UPDATE Books SET Title = {0} WHERE Id=2", "Deneme");

        }
    }
}

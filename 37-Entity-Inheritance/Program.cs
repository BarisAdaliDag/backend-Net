using _37_Entity_Inheritance.Contexts;
using _37_Entity_Inheritance.Models;

namespace _37_Entity_Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region TPH
            //Console.WriteLine("TPH");
            //TPHAppDbContext tphContext = new TPHAppDbContext();
            //tphContext.Managers.Add(new Manager() { Name = "Fatih", Bonus = 100000 });
            //tphContext.Developers.Add(new Developer() { Name = "Hüseyin", ProgLanguage = "C#,Sql" });

            //tphContext.SaveChanges();
            //Console.WriteLine("Manager");
            //var result1 = tphContext.Managers.ToList();
            //foreach (var item in result1)
            //{
            //    Console.WriteLine($"Id: {item.Id} Name: {item.Name} Bonus: {item.Bonus}");
            //}

            //Console.WriteLine("Developer");
            //var result2 = tphContext.Developers.ToList();
            //foreach (var item in result2)
            //{
            //    Console.WriteLine($"Id: {item.Id} Name: {item.Name} Lanugage: {item.ProgLanguage}");
            //}

            //Console.WriteLine("Employee");
            //var result3 = tphContext.Employees.ToList();
            //foreach (var item in result3)
            //{
            //    if (item is Developer)
            //    {
            //        var dev = (Developer)item;
            //        Console.WriteLine($"Id: {dev.Id} Name: {dev.Name} Lanugage: {dev.ProgLanguage}");
            //    }
            //    else
            //    { 
            //        var man = (Manager)item;
            //        Console.WriteLine($"Id: {man.Id} Name: {man.Name} Lanugage: {man.Bonus}");
            //    }
            //}
            #endregion

            Console.WriteLine("TPT");
            TPTAppDbContext tptContext = new TPTAppDbContext();
            //tptContext.Managers.Add(new Manager() { Name = "Fatih", Bonus = 100000 });
            //tptContext.Developers.Add(new Developer() { Name = "Hüseyin", ProgLanguage = "C#,Sql" });

            //tptContext.Employees.Add(new Employee() { Name = "Boş Gezen" });

            //tptContext.SaveChanges();
            Console.WriteLine("Manager");
            var result1 = tptContext.Managers.ToList();
            foreach (var item in result1)
            {
                Console.WriteLine($"Id: {item.Id} Name: {item.Name} Bonus: {item.Bonus}");
            }

            Console.WriteLine("Developer");
            var result2 = tptContext.Developers.ToList();
            foreach (var item in result2)
            {
                Console.WriteLine($"Id: {item.Id} Name: {item.Name} Lanugage: {item.ProgLanguage}");
            }

            Console.WriteLine("Employee");
            var result3 = tptContext.Employees.ToList();
            foreach (var item in result3)
            {
                if (item is Developer)
                {
                    var dev = (Developer)item;
                    Console.WriteLine($"Id: {dev.Id} Name: {dev.Name} Lanugage: {dev.ProgLanguage}");
                }
                else if (item is Manager)
                {
                    var man = (Manager)item;
                    Console.WriteLine($"Id: {man.Id} Name: {man.Name} Lanugage: {man.Bonus}");
                }
                else 
                {
                    Console.WriteLine($"Id: {item.Id} Name: {item.Name}");
                }
            }
        }
    }
}

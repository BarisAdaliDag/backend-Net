namespace _17_OOP_Class_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student(101, "Fatih", "Alkan") { Department = "Bilgisayar Mühendisliği" };
            student1.AddExamScore(80);
            student1.AddExamScore(90);
            student1.AddExamScore(75);

            Console.WriteLine(student1.DisplayInfo());
            Console.WriteLine("***********************************************");
            //2.SORU

            var p1 = new Product(name:"Dizüstü PC",  45000);
            var p2 = new Product("Masaüstü PC", 45000, "Elektronik");
            var p3 = new Product("Klavye", 2500, "Elektronik");

            var order = new Order(101);
            order.AddProduct(p1);
            order.AddProduct(p3);

            var order2 = new Order(102);
            order2.AddProduct(p1);
            order2.AddProduct(p3);

            List<Product> order3 = new List<Product>();
            order3.Add(p1);
            order3.Add(p3);

            Console.WriteLine(order.DisplayOrderSummary());
            Console.WriteLine(order.GetFormattedTotal());
            Console.WriteLine(order.GetMostExpensiveProduct().Name);

            Console.WriteLine("****** Order Orjinal *****");
            foreach (var item in order.Products)
            {
                Console.WriteLine(item.Price);
            }

            order.ApplyDiscount(20);
            Console.WriteLine("****** Order Indirim *****");
            foreach (var item in order.Products)
            {
                Console.WriteLine(item.Price);
            }

            Console.WriteLine("****** Order 2 *****");
            foreach (var item in order2.Products)
            {
                Console.WriteLine(item.Price);
            }

            Console.WriteLine("****** Product *****");
            foreach (var item in order3)
            {
                Console.WriteLine(item.Price);
            }


            //Console.WriteLine(order.ApplyDiscount(20));

            //Sipariş toplamını para formatında döndüren.
            //Siperiş listesindeki en pahalı ürünü bulun.
            //Belirli bir oradnda indirim uygulayan metot. (%10, %20)
        }
    }
}

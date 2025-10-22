namespace _17_OOP_Class_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student(1,"Fatih","Akin") {Department = "Bilgisayar Muhendisligi" };
            //student1.ExtraScores.Add(100);
            //student1.ExtraScores.Add(50);
            student1.AddExamScore(100);
            student1.AddExamScore(80);
            student1.AddExamScore(75);
         
            Console.WriteLine(student1.DisplayInfo());
            Console.WriteLine(student1.GetexamScores());

            Product product1 = new Product( 100, "Cikolata");
            Product product2 = new Product(100, "Cikolata");
            if(product1 == product2)
            {
                Console.WriteLine("Ayni");
            }
            else
            {
                Console.WriteLine("farkli");
            }

            var p1 = new Product(price: 2333, name: "diz ustu pc");
            var p2 = new Product(price: 1323, name: "masa ustu pc","Elektronik");
            var p3 = new Product(price: 200, name: "klavye", "Elektronik");

            var order = new Order(101);
            order.AddProduct(p1);
            order.AddProduct(p2);
            order.AddProduct(p3);
            Console.WriteLine(order.DisplayOrderSummary());

            //Siparis toplamini para formatinda donduren
            List<Product> products = new List<Product>() { p1,p2,p3,};
          
            Console.WriteLine(ProductExtensions.ChangeNumberToMoney(products) );

            //siparis listesindeki en pahali urunu bulun
            Console.WriteLine(ProductExtensions.MostExpensiveItem(products));

            //Belirli bir oranda indirim uygulayan metoto.(%10,%20)



            Console.ReadLine();

        }
    }
}
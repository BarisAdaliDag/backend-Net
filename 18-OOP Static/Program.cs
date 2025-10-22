namespace _18_OOP_Static
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //static
           // Console asd = Console() DEMIYORUZ
           //Classlari doğrudan kullanmak isteyebilirsin

            
            // Static , bir sınıfın ,methodun , alanın veya üyenın yanlızca bir örneği
            // olduğu belirtmek için kullanılan özel bir anahtar kelimedir

            //kisace statoc nesnenindegil 
            Console.WriteLine("Hello, World!");
            //Ornek.Deger = 20;
          //  Console.WriteLine(Ornek.Deger);

            Console.WriteLine(MathHelper.CalculateCircleArea(15));

            User user1 = new User() { Id = 1,Name = "Baris"};
            Console.WriteLine("Total users " + User.TotalUsersId);
            User user2 = new User() { Id = 2, Name = "Adali" };

            Console.WriteLine("Total users "+ User.TotalUsersId);

        }
    }

    public class Ornek
    {
        public string Deneme { get; set; }
        public static int Deger = 10;
        public static void Yazdir()
        {
            Console.WriteLine("Bu bir statik method");
        }
        public void DenemeInfo()
        {
            Console.WriteLine("Bu bir normal method");
        }
    }


}
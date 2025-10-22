namespace _29_OOP_InterfaceLab
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Odeme sistemine hosgeldiniz");
            Console.WriteLine("titar");
            decimal amaount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Odeme yontemi seciniz 1- kredi karit 2, hacale");
            Console.WriteLine("Secim");
            string choice = Console.ReadLine();
            BasePayment payment = null;
            switch (choice)
            {
                case "1":
                    Console.WriteLine("kart no");
                  string cardNo =  Console.ReadLine();
                    Console.WriteLine("CVV: ");
                    break;

            }
        }
    }
}
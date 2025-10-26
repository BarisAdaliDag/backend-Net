namespace _29_OOP_InterfaceLab
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Ödeme sistemine hoşgeldiniz.");
            Console.Write("Tutar: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ödeme yönetimi seçiniz: 1-Kredi Kartı, 2-Havale");
            Console.Write("Seçim");
            string choice = Console.ReadLine();

            BasePayment payment = null;

            switch (choice)
            {
                case "1":
                    Console.Write("Kart No: ");
                    string cardNo = Console.ReadLine();
                    Console.Write("CVV: ");
                    string cvv = Console.ReadLine();

                    payment = new CreditCartPayment(amount, cardNo, cvv);
                    break;
                case "2":
                    payment = new CashPayment(amount);
                    break;
                default:
                    break;
            }

            Console.WriteLine("İşlem yapılıyor...");
            payment.MakePayment();

            Console.WriteLine("Ödemeyi iptal etmek istiyormusun (E/H): ");
            string cancel = Console.ReadLine();

            if (cancel.Equals("E"))
                payment.CancelPayment();

        }
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        //STACK (yigin) yapisi son giren ilk cikar.LIFO(Last in First Out)

        Stack <int> yigin = new Stack<int>();
        yigin.Push(23);
        yigin.Push(24);
        yigin.Push(22);

        yigin.Pop();
        yigin.Peek();

        Stack<string> gecmis = new Stack<string>();
        string giris = "";
        while(true)
        {
            Console.WriteLine($"\n Tarayici Gecmisi");
            Console.WriteLine("1-sayfa ziyareti ekle");
            Console.WriteLine("2-Gecmisi listele");
            Console.WriteLine("3-geri al");
            Console.WriteLine("4-cikis");
            Console.WriteLine("Secimi yapiniz");
            giris = Console.ReadLine();
            switch ( giris )
            {
                case "1":
                    Console.WriteLine("Url:");
                    string url = Console.ReadLine();
                    gecmis.Push(url);
                    Console.WriteLine("Sayfa Eklendi");
                    break;
                case "2":
                    Console.WriteLine("url listele");
                    foreach (var item in gecmis)
                    {
                        Console.WriteLine(item);
                    }
                    
                    break;
                case "3":
                    if(gecmis.Count > 0)
                    {
                        string geriAlinanaUrl = gecmis.Pop();
                        Console.WriteLine("Geri alindi ; " + geriAlinanaUrl);

                    }
                    else
                    {
                        Console.WriteLine("Gecmis temizlendi");
                    }
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("hata tekrar dene");
                    break;


            }


        }
    }
}
internal class Program
{
    private static void Main(string[] args)
    {


        #region If Yapisi

        int not = 85;
        if (not >= 100)
        {
            Console.WriteLine("Gecersiz not");

        }
        else if (not >= 70)
        {
            Console.WriteLine("Sinavi gectiniz");
        }
        else
        {
            Console.WriteLine("Sinavi gecemediniz");
        }

        if (not == 23)
            Console.WriteLine("Tek satirda paranteze gerek yok");



















        #endregion

        #region Exapmle 1 

        // kitle endeksi hesaplama vki  degere gore kullanici zayif,normal , sisko
        //formul  vki = kilo / (boy + boy)
        /*
         * zayif 18.5 kucuk
         */
        //Console.WriteLine("Boyunuzu Giriniz (m)");
        //String strBoy = Console.ReadLine();
        //Console.WriteLine("Kilonuzu giriniz (kg)");
        //String strKilo = Console.ReadLine();
        //double boy = Convert.ToDouble(strBoy);   //double.Parse()
        //double kilo = Convert.ToDouble(strKilo);
        //double vki = kilo / (boy + boy);
        //Console.WriteLine($"Vki = {vki}");
        //if (vki < 18.5)
        //    Console.WriteLine("Zayif");
        //else if (18.5 < vki && vki < 24.9)
        //    Console.WriteLine("Normal");
        //else
        //    Console.WriteLine("Kilolu");





        #endregion

        #region Ternanary If


        int not1 = 75;
        string sonuc = not1 >= 40 ? "Gecti" : "Kaldi";

        Console.WriteLine("Sonuc " + sonuc);

        //Console.WriteLine("Sayi giriniz");
        //int sayi1 = int.Parse(Console.ReadLine());
        //Console.WriteLine(sayi1 > 0 ? "Pozitif" : (sayi1 < -29) ? "buyuk negatif" : "kucuk negatif");


        #endregion

        #region SwichtCase

        Console.WriteLine("Bir sayi girin 1-7 ");
        int gun = int.Parse(Console.ReadLine());

        switch (gun)
        {
            case 1:
                Console.WriteLine("pazartesi");
                break;
            case 2:
                Console.WriteLine("sali");
                break;
            case 3:
                Console.WriteLine("carsamba");
                break;
            case 4:
                Console.WriteLine("carsamba");
                break;
            case 5:
                Console.WriteLine("carsamba");
                break;
            default:
                Console.WriteLine("Hatali bir islem yaptiniz");
                break;


        }

        #endregion

        #region Switch-Case2
        //Swicht ile Patter Matching
        object veri = 10;
        switch (veri)
        {
            case int sayi when sayi > 0:
                Console.WriteLine("Pozitif bir tam sayi");
                break;
            case int sayi when sayi < 0:
                Console.WriteLine("Negatif bir tam sayi");
                break;
            case string:
                Console.WriteLine("Bir string girdiniz");
                break;
            default:
                Console.WriteLine("Tanimlamayan bir tur ");
                break;


        }
        Console.WriteLine("Islem seciniz (+,-,*,/)");
        double sayi1 = 5, sayi2 = 5;
        char islem = Console.ReadLine()[0];
        double sonuc1 = islem switch
        {
            '+' => sayi1 + sayi2,
            '-' => sayi1 - sayi2,
            '*' => sayi1 * sayi2,
            '/' => sayi1 / sayi2,
            _ => double.NaN

        };
        Console.WriteLine(sonuc1);


        switch (gun)
        {
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                Console.WriteLine("haftaici");
                break;
            case 6:
            case 7:
                Console.WriteLine("haftasonu");
                break;
            default:
                Console.WriteLine("Hatali bir islem yaptiniz");
                break;


        }
        #endregion
        #region Example 2 swicht

        //Ucak bilet fiyati hesaplayan kod
        //
        Console.WriteLine("Havayoluna hos geldin. ");
        
        
        Console.WriteLine("Bilet tipini belirtiniz\n1-First Class  , 2- Business class  , 3-Ekonimi class");
        int seatChoiceNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("Tek yon ise 1  Cift yon ise 2 basiniz");

        int flyWayNumber   = int.Parse(Console.ReadLine());
        Console.WriteLine("Promosyon kodunu giriniz");
        string strcode = Console.ReadLine();

        double price = 0;
        string promosyonCode = "Promosyon";

       
            switch (seatChoiceNumber)
            {
                case 1:
                    price = flyWayNumber == 1 ?1500 : 2700;
                        break;
            case 2:
                    price = flyWayNumber == 1 ? 1200 : 2000;
                break;
                case 3:
              price =  flyWayNumber == 1 ?1000 : 1800;
                break;


            }
        if(promosyonCode == strcode)
        {
            price *= 0.7;

        }
        Console.WriteLine("Bilet fiyati {0}",price);
        
        

        


        


        #endregion
    }
}
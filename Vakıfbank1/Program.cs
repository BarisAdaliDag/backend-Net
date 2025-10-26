//// See https://aka.ms/new-console-template for more information
///*
// * 
// * https://github.com/alkanfatih/Vakifbank-1
// Day-2
//kitap
//clean code

//gang of hour design design pattern


//Day- 2-1
//Domain Design System kisa tanim
//hashSet kullanimi - tekarari onlmek icin listede

//        //visual studioda paket indirdik class designer bu

//Day-2-3
//sinavda exception belirt enum kullan
//sinavda solid dusunerek islemler yap
//benzer alanlari kaldirma alt shift ş

//Abstract ile interface metotlar kalıtım aldığında chıld kullanmak zorunda
//Abstract Classı genelde BaseClass oluşumunda kulla kullanıyoruz
//Interface gevşek bağlantı  loose coupling alkanfatih.com

//day 2-4
//crud operasyonu interface hata durumlari on hazirlik yap
//using dispose otomatik yapiyor/

// */

////Alt enter





///// <summary>
///// N Sayıda değişkeni toplayan metot.
///// </summary>
///// <param name="sayilar">Birden fazla sayı girişi</param>
///// <returns>Sayıların toplam değeri</returns>
//public static int Topla(params int[] sayilar)
//{
//    int toplam = 0;
//    foreach (var item in sayilar)
//    {
//        toplam += item;
//    }
//    return toplam;
//}

///// <summary>
///// Bölme işlemini gerçekleştirir.
///// </summary>
///// <param name="bolunen">Bölünecek sayı</param>
///// <param name="bolen">Bölen sayı</param>
///// <param name="kalan">Kalan sayı</param>
///// <returns>Sonuç</returns>
//public static double Bolme(double bolunen, double bolen, out double kalan)
//{
//    kalan = bolunen % bolen;
//    return bolunen / bolen;
//}

//public static void DegeriDegistir(ref int x)
//{
//    x = x + 10;
//}

//        #region BestPracties
//        /*Adlandırma Kuralları
//         * 1-Anlamlı isimler: CalculateTotalPrice
//         * 2-Fiil Kullanımı: GetCustomer, SaveFile, SendEmail gibi
//         * 3-CamelCase ve PascalCase: C# dilinde metot isimleri genellikle PascalCase kullanılır. SendNatification()
//         *Tek Sorumluluk Prensibi (Signle Responsibility)
//         *Metotlar Kısa ve Öz Olmalıdır. (20 satırdan uzun olamamlıdır.)
//         *Paramtere Sayısını Minimize Edin.
//         *Dökümantasyon ve Yorum Satırları
//         *DRY (Don't Repeat Yourself) Kendi edini tekrar etme.
//         */

//using System.Collections;

//internal class Program
//{
//    static void Main(string[] args)
//    {


//        //TYPE CHECKING

//        object item = 5;
//        Console.WriteLine(item.GetType()); // Çıktı: System.Int32
//        Type t = typeof(int);
//        Console.WriteLine(t); // Çıktı: System.Int32


//        object item = 42;

//        if (item.GetType() == typeof(int))
//            Console.WriteLine("Tam olarak int tipi.");
//        else if (item is string)
//            Console.WriteLine("String veya alt tipi.");
//        else
//            Console.WriteLine("Farklı bir tip.");

//        // TYPE CASTING
//        ArrayList list = new ArrayList() { 10, "merhaba", 5 };

//        foreach (var item in list)
//        {
//            if (item.GetType() == typeof(int))
//            {
//                int sonuc = (int)item * 2;
//                Console.WriteLine(sonuc); // Çıktı: 20 ve 10
//            }
//        }

  
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
//    }

//}


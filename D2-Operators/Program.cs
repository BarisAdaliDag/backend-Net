internal class Program
{
    private static void Main(string[] args)
    {
        //Operatorler c# programlama dilinde uzerinde cesitli islamler gercektirmeyi saglayan sembolik ifadeler

        #region Aritmetik Operatorler
        int a = 5, b = 6;
        int toplam = a + b;
        Console.WriteLine("Sonuc: {0}",toplam);

        //Birlestirme (+)
        string ilk = "Merhaba";
        string ikinci = "Dunya";
        string cumle = ilk + ikinci;
        Console.WriteLine("Cumlu {0}", cumle);


        //Bolme
        int g = 20;
        int h = 3;
        double bolum = (double)g / h;
        Console.WriteLine($"Kalan {bolum}");
        // bolum int olursa veri kaybi olur islemlerden biri double olmak zorunda veriyi double tumasi icin
        




        //Mod (%)
        int n = 10;
        int m = 3;
      
        Console.WriteLine($"kalan {m%n}");

        #endregion

        #region Atama Operatorler

        int sayi = 5;
        sayi += 10;
        
        int farki = 199; 
        farki -= 10;

        int carpim = 7;
        carpim *= 4;

        double bolum1 = 10;
        bolum1/= 2;

        //Arttirma Operatoleri 
        int sayi2 = 5;
        sayi2 += 1;
       


        //++Sayi
        int sayi3 = 10;
        ++sayi3;

        //burada once islemi yapar sonra atamayi yapar

        //Sayi++
        int sayi4 = 10;
        sayi4++;

        int i = 5;
        int j = ++i + i++ + ++i + i;
        //       6     6     8    8


        Console.WriteLine($"Sonuc j {j}");
        Console.WriteLine($" Son durmda i = {i}");









        #endregion

        #region Karsilastirma Opetatorleri

        //Esitlik
        int a1 = 5, b1 = 5;
        bool esitmi = a1 == b1;
        Console.WriteLine(esitmi);

        string c = "1234", d = "1234";
        bool esitmi2 = c== d;
        Console.WriteLine(esitmi2);

        //Esitsizlik

        bool esitmi3 = c!= d;
        Console.WriteLine($"Esit degil {esitmi3}");

        bool esitmi4 = a < b;
        bool esitmi5 = a > b;
        bool esitmi6 = a <= b;




        #endregion

        #region Mantiksal Operatorler

        bool a5 = true;
        bool b5 = false;
        bool sonuc5 = a5 && b5; // & oldugunda ilk ifade false oldugunda digerine bakmiyor cift oldugunda yan tarafa bakiyor
        bool sonuc =  a5 || b5;


        //Escape Sequence
        Console.WriteLine("Merhaba \n Hosgeldiniz \" Alinti \"  WEb  adresi https:\\\\aa.com");

        #endregion
    }
}
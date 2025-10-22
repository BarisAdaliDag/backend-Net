internal class Program
{
    private static void Main(string[] args)
    {
        #region List

        List<int> sayilar = new List<int>() { 10,20,5};
        sayilar.Add(1);
        sayilar.Add(2);
        sayilar.Remove(5);
        sayilar.Remove(1);
        Console.WriteLine(sayilar);
        sayilar.Insert(1, 200000000);
        sayilar.Sort();//Arryden turemis index


        //Datalari okumak
        Console.WriteLine(sayilar[2]);

        for(int i = 0; sayilar.Count > i; i++)
        {
            Console.WriteLine(sayilar[i]);
        }

        Console.WriteLine("for each");

        foreach(var item in sayilar)
        {
            Console.WriteLine(item);
        }
        sayilar.ForEach(item => Console.WriteLine(item));



        #endregion
        #region Tuple


        var person = (Id: 1, Name: "Fatih", IsActive: true);
        string ad, sinif;
        int not;
        bool dogruMu;

        List<(string Ad,string Sinif,int Not)> ogrencilier = new List<(string Ad, string Sinif, int Not)>();

        //ogrenci Bilgeri kullanicidan alma

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($" Ogrenci Bilgileri giriniz {i+1}");
            Console.Write("Adi:");
            ad = Console.ReadLine();

            Console.Write("Sinif");
            sinif = Console.ReadLine();

            do
            {
                Console.Write("Notu:");
                dogruMu = int.TryParse(Console.ReadLine(), out not);
                Console.WriteLine(dogruMu ? $"Giris bilgileri basarili" : "Basarisiz");

            } while (!dogruMu);
            ogrencilier.Add((ad, sinif, not));


        }
       

        //Tum ogrenci listele
        Console.WriteLine("Ogrenci Bilgileri");
        foreach (var ogrenci in ogrencilier)
        {
            Console.WriteLine($"Ad: {ogrenci.Ad} , sinif {ogrenci.Sinif} ,not {ogrenci.Not} ");
        }

        //Notleri kucukten buyuge siralama
        var siraliNorlar = ogrencilier.OrderBy(o => o.Not);
        Console.WriteLine(" Notlar Kucukten buyuge siralama");

        foreach (var ogrenci in ogrencilier)
        {
            Console.WriteLine($"Ad: {ogrenci.Ad} , sinif {ogrenci.Sinif} ,not {ogrenci.Not} ");
        }

        //en yukse knotu bulma
        var enYuksekNot= ogrencilier.OrderByDescending(o => o.Not).FirstOrDefault();//[0] olurdu
      //  Console.WriteLine("En yuksek notu alan ogrenci "+enYuksekNot.Ad + "  " , +enYuksekNot.Sinif+ " " + enYuksekNot.Not);



        #endregion

    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        #region List
        List<int> sayilar = new List<int>() { 10, 20, 5 };
        sayilar.Add(7);
        sayilar.Add(12);
        sayilar.Remove(5);
        sayilar.RemoveAt(1);
        sayilar.Insert(2, 5);

        //Dataları okumak.
        Console.WriteLine(sayilar[1]);

        Console.WriteLine("\nFor Döngüsü\n");
        for (int i = 0; i < sayilar.Count; i++)
        {
            Console.WriteLine(sayilar[i]);
        }

        Console.WriteLine("\nForeach Döngüsü\n");
        foreach (var item in sayilar)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\nForeach Döngüsü 2\n");
        sayilar.ForEach(x => Console.WriteLine(x));
        #endregion

        #region Tupple
        var person = (Id: 1, Name: "Fatih", IsActive: true);
        Console.WriteLine(person.Name);

        #endregion

        #region Example
        string ad, sinif;
        int not;
        bool dogruMu;

        List<(string Ad, string Sinif, int Not)> ogrenciler = new List<(string Ad, string Sinif, int No)>();

        //Öğrenci bilgilerini kullanıcıdan alma
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"\nÖğrenci {i + 1} bilgilerini girininiz.");

            Console.Write("Adı: ");
            ad = Console.ReadLine();

            Console.Write("Sınıfı: ");
            sinif = Console.ReadLine();

            do
            {
                Console.Write("Notu: ");
                dogruMu = int.TryParse(Console.ReadLine(), out not);
                Console.WriteLine(dogruMu ? "Giriş işlemleri başarılı" : "Hatalı not girişi!");
            } while (!dogruMu);

            ogrenciler.Add((ad, sinif, not));
        }

        //Tüm öğrencileri listele
        Console.WriteLine("\nÖğrenci Bilgileri");
        foreach (var ogrenci in ogrenciler)
        {
            Console.WriteLine($"Öğrenci Ad: {ogrenci.Ad}, Sınıf: {ogrenci.Sinif}, Not: {ogrenci.Not}");
        }

        //Notları küçükten büyüğe sıralam
        var siraliNotlar = ogrenciler.OrderBy(o => o.Not);
        Console.WriteLine("\nNotlar küçükten büyüğe sıralanmış");
        foreach (var item in siraliNotlar)
        {
            Console.WriteLine($"Öğrenci Ad: {item.Ad}, Sınıf: {item.Sinif}, Not: {item.Not}");
        }

        //En Yüksek notu bulma
        var enYuksekNot = ogrenciler.OrderByDescending(o => o.Not).FirstOrDefault();
        Console.WriteLine($"\nEn yüksek not alan öğrenci adı: {enYuksekNot.Ad} sınıf: {enYuksekNot.Sinif} not: {enYuksekNot.Not}");


        #endregion

    }
}
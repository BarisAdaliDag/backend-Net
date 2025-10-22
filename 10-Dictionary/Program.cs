internal class Program
{
    private static void Main(string[] args)
    {
        // Dictionanry key-value ciftlerini saklayan koleksiyon yapisi

        Dictionary<int,string> ogrenciler = new Dictionary<int, string>();
        ogrenciler.Add(101, "Ali");
        ogrenciler.Add(102, "Ayse");
     
     //   ogrenciler.Remove(102);
        ogrenciler.ContainsKey(102);//True

        Console.WriteLine(ogrenciler[102]);

        string isim;
        if (ogrenciler.TryGetValue(102, out isim))
        {
            Console.WriteLine(isim);
        }
        Dictionary<string,int> ogrenciNotlari = new Dictionary<string,int>();
        string girls = "";
        while (true)
        {
            Console.WriteLine("Ogrenci Notlari Yonetim Sistemi");
            Console.WriteLine("1. Not Ekle");
            Console.WriteLine("2.Not listele");
            Console.WriteLine("3-Not guncelle");
            Console.WriteLine("4-Not sil");
            Console.WriteLine("5-Cikis Yap");

            girls= Console.ReadLine();
            ogrenciStart:
            switch (girls)
            {
                case "1":
                    Console.WriteLine("Ogrenci Adi: ");
                    string ogrenciAdi = Console.ReadLine();
                    Console.WriteLine("Ogrenci Notu: ");
                    int ogrenciNotu = int.Parse(Console.ReadLine());
                    if (ogrenciNotlari.ContainsKey(ogrenciAdi))
                    {
                        Console.WriteLine("Bu ogrencini not bilgisi mevcut");
                        goto ogrenciStart;
                    }
                    ogrenciNotlari.Add(ogrenciAdi, ogrenciNotu);
                    Console.WriteLine("Not eklendi");

                    break;
                case "2":
                    Console.WriteLine("ogenci Notlari");
                    foreach (var ogrenci in ogrenciNotlari)
                    {
                        Console.WriteLine($"Ogrenci{ogrenci.Key} notu {ogrenci.Value}");

                    }

                    break;
                case "3":
                    Console.Write("Guncelleme istediginiz ogrenci adi ");

                    string guncellleAdi = Console.ReadLine();
                    if (ogrenciNotlari.ContainsKey(guncellleAdi));
                    {
                        Console.WriteLine($"{guncellleAdi} icin guncel not{ogrenciNotlari[guncellleAdi]} \n yeni not giriniz");
                    int yeniNot = int.Parse(Console.ReadLine());
                    ogrenciNotlari[guncellleAdi] = yeniNot;
                    Console.WriteLine($"{guncellleAdi} icin guncelenmis not{ogrenciNotlari[guncellleAdi]} ");

        }


                    break;
                case "4":
                    Console.WriteLine("Silmek istediginiz ogrencinin adini girin:");
                    string silinecekAd = Console.ReadLine();
                    if (ogrenciNotlari.Remove(silinecekAd)){
                        Console.WriteLine("Ogrenci adi silindi");
                    }

                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Gecersiz Islem Yaptiniz Tekrar Deneyiniz");
                    break;


            }


        }

    }
}
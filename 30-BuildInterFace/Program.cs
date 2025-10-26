using _30_OOP_BuiltInInterface.Example_1;
using _30_OOP_BuiltInInterface.Example_2;
using _30_OOP_BuiltInInterface.Example_3;


namespace _30_OOP_BuiltInInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Example-1
            Kitaplık kitaplik = new Kitaplık();
            Console.WriteLine(kitaplik.Capacity);
            Console.WriteLine(kitaplik.Count);
            Console.WriteLine("************************");
            kitaplik.Add(new Kitap { Ad = "Kitap-1", Yazar = "Yazar-1" });
            kitaplik.Add(new Kitap { Ad = "Kitap-2", Yazar = "Yazar-2" });
            Console.WriteLine(kitaplik.Capacity);
            Console.WriteLine(kitaplik.Count);
            Console.WriteLine("************************");
            kitaplik.Add(new Kitap { Ad = "Kitap-3", Yazar = "Yazar-3" });
            Console.WriteLine(kitaplik.Capacity);
            Console.WriteLine(kitaplik.Count);
            kitaplik.Remove(new Kitap { Ad = "Kitap-3", Yazar = "Yazar-3" });
            kitaplik.Remove(new Kitap { Ad = "Kitap-2", Yazar = "Yazar-2" });
            Console.WriteLine(kitaplik.Capacity);
            Console.WriteLine(kitaplik.Count);

            //foreach (var item in kitaplik)
            //{
            //    Console.WriteLine(item.Ad + " " + item.Yazar);
            //}

            //Console.WriteLine("Adet: " + kitaplik.Count);

            #endregion
            
            #region Example-2
            List<Ogrenci> ogrencis = new List<Ogrenci>()
            {
                new Ogrenci { Ad="Ahmet", Ortalama=72.5 },
                new Ogrenci { Ad="Mehmet", Ortalama=68.4 },
                new Ogrenci { Ad="Ayşe", Ortalama=82.3 },
            };
            ogrencis.Sort(new OgrenciOrtalamaKarsilasitirici());
            foreach (var item in ogrencis)
            {
                Console.WriteLine(item.Ad + " " + item.Ortalama);
            }
            Console.WriteLine(ogrencis.Contains(new Ogrenci { Ad = "Ayşe", Ortalama = 82.3 }));


            List<string> strings = new List<string>() { "Istanbul", "Ankra", "Rize" };
            strings.Sort();
            foreach (var item in strings)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(strings.Contains("Rize"));

            var ogrenci1 = new Ogrenci() { Ad = "Zeynep", Ortalama = 45 };
            var ogrenci2 = (Ogrenci)ogrenci1.Clone();

            Console.WriteLine("Eşitlik Kontrolü");
            Console.WriteLine(ogrenci1 == ogrenci2);

            #endregion

            #region Example-3

            using (var yazici = new DosyaYazici("ornek.txt"))
            {
                yazici.Yaz("Merhaba");
            }

            #endregion
        }
    }
}

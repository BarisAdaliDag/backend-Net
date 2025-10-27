// =======================================================
// C# OOP - KALITIM (INHERITANCE) - NOTLAR
// Tek dosya, sadece okuma ve not amaçlı
// Çalıştırma amaçlı değil, Main yok
// =======================================================

using System;
using System.Collections.Generic;

namespace Vakıfbank1
{
    #region Inheritance Nedir?
    // Inheritance Nedir?
    // Bir sınıfın başka bir sınıftan özellik ve metodlarını miras almasıdır.
    // Kod tekrarını önler ve hiyerarşik yapı oluşturur.
    #endregion

    #region Temel Kullanım
    // Base (Ana) Sınıf
    class Hayvan
    {
        public string Isim { get; set; }
        public int Yas { get; set; }

        public void SesCikar()
        {
            Console.WriteLine("Hayvan ses çıkarıyor");
        }
    }

    // Derived (Türetilmiş) Sınıf
    class Kopek : Hayvan
    {
        public string Cins { get; set; }

        public void Havla()
        {
            Console.WriteLine("Hav hav!");
        }
    }

    // Kullanım
    // Kopek kopek = new Kopek();
    // kopek.Isim = "Karabaş";    // Base sınıftan
    // kopek.Yas = 3;             // Base sınıftan
    // kopek.Cins = "Golden";     // Kendi özelliği
    // kopek.SesCikar();          // Base sınıftan
    // kopek.Havla();             // Kendi metodu
    #endregion

    #region Constructor Zinciri
    class Hayvan2
    {
        public string Isim { get; set; }

        public Hayvan2(string isim)
        {
            Isim = isim;
            Console.WriteLine("Hayvan constructor çalıştı");
        }
    }

    class Kopek2 : Hayvan2
    {
        public string Cins { get; set; }

        // Base constructor'ı çağırma
        public Kopek2(string isim, string cins) : base(isim)
        {
            Cins = cins;
            Console.WriteLine("Köpek constructor çalıştı");
        }
    }

    // Kullanım
    // Kopek kopek = new Kopek("Karabaş", "Golden");
    // Çıktı:
    // Hayvan constructor çalıştı
    // Köpek constructor çalıştı
    #endregion

    #region Virtual ve Override
    class Hayvan3
    {
        // Virtual - Türetilmiş sınıflar override edebilir
        public virtual void SesCikar()
        {
            Console.WriteLine("Hayvan ses çıkarıyor");
        }

        public virtual string BilgiVer()
        {
            return "Bu bir hayvandır";
        }
    }
   

    class Kopek3 : Hayvan3
    {
        // Override - Base metodun üzerine yazar
        public override void SesCikar()
        {
            Console.WriteLine("Hav hav!");
        }

        public override string BilgiVer()
        {
            return "Bu bir köpektir";
        }
    }

    class Kedi : Hayvan3
    {
        public override void SesCikar()
        {
            Console.WriteLine("Miyav!");
        }
    }

    // Kullanım
    // Hayvan hayvan1 = new Kopek();
    // Hayvan hayvan2 = new Kedi();
    // hayvan1.SesCikar(); // "Hav hav!"
    // hayvan2.SesCikar(); // "Miyav!"
    #endregion

    #region Base Keyword
    class Calisan
    {
        public string Isim { get; set; }
        public decimal Maas { get; set; }

        public virtual decimal MaasHesapla()
        {
            return Maas;
        }
    }

    class Mudur : Calisan
    {
        public decimal Prim { get; set; }

        public override decimal MaasHesapla()
        {
            // Base sınıfın metodunu çağır
            decimal temelMaas = base.MaasHesapla();
            return temelMaas + Prim;
        }
    }

    // Kullanım
    // Mudur mudur = new Mudur { Isim = "Ali", Maas = 10000, Prim = 3000 };
    // Console.WriteLine(mudur.MaasHesapla()); // 13000
    #endregion

    #region Sealed Keyword
    // Sealed Class - Miras alınamaz
    sealed class SonSinif
    {
        public void Metod()
        {
            Console.WriteLine("Bu sınıftan miras alınamaz");
        }
    }

    // HATA: Sealed sınıftan miras alınamaz
    // class DenemeClass : SonSinif { }

    // Sealed Method - Override edilemez
    class Hayvan4
    {
        public virtual void SesCikar()
        {
            Console.WriteLine("Hayvan sesi");
        }
    }

    class Kopek4 : Hayvan4
    {
        // Bu metod artık override edilemez
        public sealed override void SesCikar()
        {
            Console.WriteLine("Hav hav!");
        }
    }

    class GoldenRetriever : Kopek4
    {
        // HATA: Sealed metod override edilemez
        // public override void SesCikar() { }
    }
    #endregion

    #region Abstract Sınıflar
    // Abstract Class - Direkt instance oluşturulamaz
    abstract class Sekil
    {
        public string Renk { get; set; }

        // Abstract metod - Mutlaka override edilmeli
        public abstract double AlanHesapla();

        // Normal metod
        public void BilgiYaz()
        {
            Console.WriteLine($"Renk: {Renk}, Alan: {AlanHesapla()}");
        }
    }

    class Daire : Sekil
    {
        public double YariCap { get; set; }

        // Abstract metod mutlaka implement edilmeli
        public override double AlanHesapla()
        {
            return Math.PI * YariCap * YariCap;
        }
    }

    class Dikdortgen : Sekil
    {
        public double En { get; set; }
        public double Boy { get; set; }

        public override double AlanHesapla()
        {
            return En * Boy;
        }
    }

    // Kullanım
    // Sekil sekil = new Sekil(); // HATA: Abstract sınıf
    // Sekil daire = new Daire { Renk = "Kırmızı", YariCap = 5 };
    // daire.BilgiYaz();
    #endregion

    #region Çok Katmanlı Kalıtım
    class CanliVarlik
    {
        public bool YaşıyorMu { get; set; }

        public void Yasam()
        {
            Console.WriteLine("Canlı varlık yaşıyor");
        }
    }

    class Hayvan5 : CanliVarlik
    {
        public string Isim { get; set; }

        public virtual void SesCikar()
        {
            Console.WriteLine("Hayvan ses çıkarıyor");
        }
    }

    class Memeli : Hayvan5
    {
        public bool SutEmzirir { get; set; }
    }

    class Kopek5 : Memeli
    {
        public string Cins { get; set; }

        public override void SesCikar()
        {
            Console.WriteLine("Hav hav!");
        }
    }

    // Kullanım
    // Kopek kopek = new Kopek();
    // kopek.YaşıyorMu = true;        // CanliVarlik'ten
    // kopek.Isim = "Karabaş";        // Hayvan'dan
    // kopek.SutEmzirir = true;       // Memeli'den
    // kopek.Cins = "Golden";         // Kendi özelliği
    // kopek.Yasam();                 // CanliVarlik'ten
    // kopek.SesCikar();              // Override edilmiş
    #endregion

    #region Polimorfizm (Polymorphism)
    class Calisan2
    {
        public string Isim { get; set; }
        public virtual void Calis()
        {
            Console.WriteLine("Çalışan çalışıyor");
        }
    }

    class Yazilimci : Calisan2
    {
        public override void Calis()
        {
            Console.WriteLine("Kod yazıyor");
        }
    }

    class Tasarimci : Calisan2
    {
        public override void Calis()
        {
            Console.WriteLine("Tasarım yapıyor");
        }
    }

    // Polimorfizm kullanımı
    // List<Calisan> calisanlar = new List<Calisan>
    // {
    //     new Yazilimci { Isim = "Ali" },
    //     new Tasarimci { Isim = "Ayşe" },
    //     new Calisan { Isim: "Mehmet" }
    // };
    //
    // foreach (var calisan in calisanlar)
    // {
    //     Console.Write($"{calisan.Isim}: ");
    //     calisan.Calis(); // Her sınıf kendi metodunu çalıştırır
    // }
    // Çıktı:
    // Ali: Kod yazıyor
    // Ayşe: Tasarım yapıyor
    // Mehmet: Çalışan çalışıyor
    #endregion

    #region Type Checking ve Casting
    class Hayvan6
    {
        public string Isim { get; set; }
    }

    class Kopek6 : Hayvan6
    {
        public void Havla() => Console.WriteLine("Hav!");
    }

    class Kedi2 : Hayvan6
    {
        public void Miyavla() => Console.WriteLine("Miyav!");
    }

    // is operatörü - Tip kontrolü
    // Hayvan hayvan = new Kopek { Isim = "Karabaş" };
    //
    // if (hayvan is Kopek)
    // {
    //     Console.WriteLine("Bu bir köpek");
    // }

    // as operatörü - Güvenli casting
    // Kopek kopek = hayvan as Kopek;
    // if (kopek != null)
    // {
    //     kopek.Havla();
    // }

    // Pattern matching (C# 7+)
    // if (hayvan is Kopek k)
    // {
    //     k.Havla(); // Direkt kullanılabilir
    // }

    // Direct casting
    // Kopek kopek2 = (Kopek)hayvan; // Exception fırlatabilir

    // typeof ve GetType
    // Type tip = typeof(Kopek);
    // Type hayvanTip = hayvan.GetType();
    // Console.WriteLine(hayvanTip == typeof(Kopek)); // true
    #endregion

    #region Pratik Örnekler

    // Örnek 1: Banka Hesap Sistemi
    abstract class BankaHesabi
    {
        public string HesapNo { get; set; }
        public decimal Bakiye { get; protected set; }

        public virtual void ParaYatir(decimal miktar)
        {
            Bakiye += miktar;
            Console.WriteLine($"{miktar} TL yatırıldı. Bakiye: {Bakiye}");
        }

        public abstract void ParaCek(decimal miktar);
    }

    class VadesizHesap : BankaHesabi
    {
        public override void ParaCek(decimal miktar)
        {
            if (Bakiye >= miktar)
            {
                Bakiye -= miktar;
                Console.WriteLine($"{miktar} TL çekildi");
            }
        }
    }

    class KrediKarti : BankaHesabi
    {
        public decimal Limit { get; set; }

        public override void ParaCek(decimal miktar)
        {
            if (Bakiye + Limit >= miktar)
            {
                Bakiye -= miktar;
                Console.WriteLine($"{miktar} TL harcandı");
            }
        }
    }

    // Örnek 2: Araç Sistemi
    class Arac
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        public int Yil { get; set; }

        public virtual void BilgiGoster()
        {
            Console.WriteLine($"{Yil} {Marka} {Model}");
        }
    }

    class Otomobil : Arac
    {
        public int KapiSayisi { get; set; }

        public override void BilgiGoster()
        {
            base.BilgiGoster();
            Console.WriteLine($"Kapı sayısı: {KapiSayisi}");
        }
    }

    class Motosiklet : Arac
    {
        public int MotorHacmi { get; set; }

        public override void BilgiGoster()
        {
            base.BilgiGoster();
            Console.WriteLine($"Motor hacmi: {MotorHacmi}cc");
        }
    }
    #endregion

    #region Önemli Kurallar
    // C#'ta:
    // - Tek sınıftan miras alınır (multiple inheritance yok)
    // - Ama birden fazla interface implement edilebilir
    // - Her sınıf Object sınıfından türer

    // Dikkat:
    // - `virtual` olmayan metodlar override edilemez
    // - `private` üyeler miras alınmaz
    // - Constructor'lar miras alınmaz ama çağrılabilir (base)
    // - `sealed` sınıf ve metodlar miras alınamaz/override edilemez

    // Kullanım:
    // - Kod tekrarını önlemek için
    // - Ortak davranışları gruplamak için
    // - Polimorfizm sağlamak için
    // - "IS-A" ilişkisi varsa (Köpek bir Hayvandır)
    #endregion
}
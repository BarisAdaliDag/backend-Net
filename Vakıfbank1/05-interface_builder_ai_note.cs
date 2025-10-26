using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vakıfbank1
{
    // ======================================================
    // C# OOP – INTERFACE (ARAYÜZ) – TAM NOT DOSYASI
    // ======================================================
    // Bu dosya sadece not amaçlıdır. Program.cs gerekmez.
    // Visual Studio'da #region ile katlanabilir.

    // ==========================================================
    #region 1. INTERFACE NEDİR?
    // ----------------------------------------------------------
    // Interface, bir sınıfın NE YAPMASI GEREKTİĞİNİ tanımlar,
    // ama NASIL yapacağını belirtmez.
    // Sadece metod, property, event imzası içerir.
    #endregion

    // ==========================================================
    #region 2. TEMEL INTERFACE TANIMLAMA
    // ----------------------------------------------------------
    interface ICalisan
    {
        string Ad { get; set; }
        decimal Maas { get; }
        void Calis();
        decimal MaasHesapla();
        string BilgiGetir();
    }

    class Yazilimci : ICalisan
    {
        public string Ad { get; set; }
        public decimal Maas { get; private set; }
        public string ProgramlamaDili { get; set; }

        public Yazilimci(string ad, decimal maas) { Ad = ad; Maas = maas; }

        public void Calis() => Console.WriteLine($"{Ad} kod yazıyor");
        public decimal MaasHesapla() => Maas * 1.2m;
        public string BilgiGetir() => $"{Ad} - {ProgramlamaDili} Developer";
    }

    class Mudur : ICalisan
    {
        public string Ad { get; set; }
        public decimal Maas { get; private set; }
        public int TakimSayisi { get; set; }

        public Mudur(string ad, decimal maas) { Ad = ad; Maas = maas; }

        public void Calis() => Console.WriteLine($"{Ad} toplantı yapıyor");
        public decimal MaasHesapla() => Maas * 1.5m;
        public string BilgiGetir() => $"{Ad} - Müdür ({TakimSayisi} takım)";
    }

    // Polimorfizm
    // List<ICalisan> calisanlar = new() { new Yazilimci("Ali", 10000) { ProgramlamaDili = "C#" }, ... };
    #endregion

    // ==========================================================
    #region 3. ÇOKLU INTERFACE IMPLEMENTATION
    // ----------------------------------------------------------
    interface IYuzebilir { void Yuz(); }
    interface IUcabilir { void Uc(); }
    interface IKosabilir { void Kos(); }

    class Ordek : IYuzebilir, IUcabilir, IKosabilir
    {
        public void Yuz() => Console.WriteLine("Ördek yüzüyor");
        public void Uc() => Console.WriteLine("Ördek uçuyor");
        public void Kos() => Console.WriteLine("Ördek koşuyor");
    }

    class Balik : IYuzebilir
    {
        public void Yuz() => Console.WriteLine("Balık yüzüyor");
    }

    class Kus : IUcabilir
    {
        public void Uc() => Console.WriteLine("Kuş uçuyor");
    }

    // void HavuzaGir(IYuzebilir canli) => canli.Yuz();
    #endregion

    // ==========================================================
    #region 4. INTERFACE INHERITANCE (Kalıtım)
    // ----------------------------------------------------------
    interface IVarlik
    {
        string Id { get; }
        DateTime OlusturmaTarihi { get; }
    }

    interface IKaydedilebilir : IVarlik { void Kaydet(); void Guncelle(); }
    interface ISilinebilir : IVarlik { void Sil(); bool SilindiMi { get; } }

    interface ITamYetkili : IKaydedilebilir, ISilinebilir { void YedekAl(); }

    class Kullanici : ITamYetkili
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;
        public bool SilindiMi { get; private set; }
        public string Ad { get; set; }

        public void Kaydet() => Console.WriteLine($"Kullanıcı {Ad} kaydedildi");
        public void Guncelle() => Console.WriteLine($"Kullanıcı {Ad} güncellendi");
        public void Sil() { SilindiMi = true; Console.WriteLine($"Kullanıcı {Ad} silindi"); }
        public void YedekAl() => Console.WriteLine($"Kullanıcı {Ad} yedeklendi");
    }
    #endregion

    // ==========================================================
    #region 5. EXPLICIT INTERFACE IMPLEMENTATION
    // ----------------------------------------------------------
    // Aynı isimde metodlar varsa çakışmayı önler
    interface IArabaKiralama { void Kirala(); void TeslimEt(); }
    interface IEvKiralama { void Kirala(); void TeslimEt(); }

    class KiralamaSirketi : IArabaKiralama, IEvKiralama
    {
        void IArabaKiralama.Kirala() => Console.WriteLine("Araba kiralandı");
        void IArabaKiralama.TeslimEt() => Console.WriteLine("Araba teslim edildi");
        void IEvKiralama.Kirala() => Console.WriteLine("Ev kiralandı");
        void IEvKiralama.TeslimEt() => Console.WriteLine("Ev teslim edildi");

        public void GenelBilgi() => Console.WriteLine("Kiralama şirketi");
    }

    // Kullanım:
    // ((IArabaKiralama)sirket).Kirala(); → Araba kiralandı
    #endregion

    // ==========================================================
    #region 6. DEFAULT INTERFACE METHODS (C# 8.0+)
    // ----------------------------------------------------------
    interface ILogger
    {
        void Log(string mesaj);

        void LogBilgi(string mesaj) => Log($"[BİLGİ] {mesaj}");
        void LogHata(string mesaj) => Log($"[HATA] {mesaj}");
        void LogUyari(string mesaj) => Log($"[UYARI] {mesaj}");

        static void Baslik() => Console.WriteLine("=== LOGGER ===");
    }

    class KonsolLogger : ILogger
    {
        public void Log(string mesaj) => Console.WriteLine($"{DateTime.Now}: {mesaj}");
        // Default metodlar otomatik gelir
    }

    class DosyaLogger : ILogger
    {
        public void Log(string mesaj) => Console.WriteLine($"Dosyaya: {mesaj}");
        public void LogHata(string mesaj) => Log($"!!! KRİTİK HATA: {mesaj} !!!");
    }
    #endregion

    // ==========================================================
    #region 7. GENERIC INTERFACE
    // ----------------------------------------------------------
    interface IRepository<T> where T : class
    {
        void Ekle(T entity);
        void Sil(int id);
        void Guncelle(T entity);
        T IdyeGoreGetir(int id);
        List<T> TumunuGetir();
    }

    class Urun { public int Id { get; set; } public string Ad { get; set; } public decimal Fiyat { get; set; } }

    class UrunRepository : IRepository<Urun>
    {
        private List<Urun> urunler = new();

        public void Ekle(Urun entity) { urunler.Add(entity); Console.WriteLine($"{entity.Ad} eklendi"); }
        public void Sil(int id) { var u = urunler.FirstOrDefault(x => x.Id == id); if (u != null) { urunler.Remove(u); Console.WriteLine($"{u.Ad} silindi"); } }
        public void Guncelle(Urun entity) { /* ... */ }
        public Urun IdyeGoreGetir(int id) => urunler.FirstOrDefault(x => x.Id == id);
        public List<Urun> TumunuGetir() => urunler;
    }
    #endregion

    // ==========================================================
    #region 8. INTERFACE İLE DEPENDENCY INJECTION
    // ----------------------------------------------------------
    interface IEmailService { void EmailGonder(string kime, string mesaj); }
    interface ISmsService { void SmsGonder(string numara, string mesaj); }

    class GmailService : IEmailService { public void EmailGonder(string k, string m) => Console.WriteLine($"Gmail: {k}'e gönderildi"); }
    class TurkcellSms : ISmsService { public void SmsGonder(string n, string m) => Console.WriteLine($"Turkcell: {n}'ya SMS"); }

    class BildirimServisi
    {
        private readonly IEmailService _email;
        private readonly ISmsService _sms;

        public BildirimServisi(IEmailService email, ISmsService sms)
        {
            _email = email; _sms = sms;
        }

        public void KullaniciyaBildir(string email, string tel, string mesaj)
        {
            _email.EmailGonder(email, mesaj);
            _sms.SmsGonder(tel, mesaj);
        }
    }
    #endregion

    // ==========================================================
    #region 9. PRATİK ÖRNEK: ÖDEME SİSTEMİ
    // ----------------------------------------------------------
    interface IOdemeYontemi
    {
        string YontemAdi { get; }
        bool OdemeYap(decimal tutar, string bilgi);
        bool OdemeIadeEt(string islemNo, decimal tutar);
        string IslemDurumSorgula(string islemNo);
    }

    interface ITaksitlenebilir
    {
        int MaxTaksitSayisi { get; }
        decimal TaksitFaizOrani { get; }
        List<decimal> TaksitPlaniOlustur(decimal tutar, int taksitSayisi);
    }

    interface I3DSecure
    {
        bool DogrulamaYap(string kod);
        string DogrulamaKoduGonder(string telefon);
    }

    class KrediKarti : IOdemeYontemi, ITaksitlenebilir, I3DSecure
    {
        public string YontemAdi => "Kredi Kartı";
        public int MaxTaksitSayisi => 12;
        public decimal TaksitFaizOrani => 1.5m;

        public bool OdemeYap(decimal tutar, string kartNo)
        {
            Console.WriteLine($"{YontemAdi}: {tutar} TL - ****{kartNo[^4..]}");
            return true;
        }
        public bool OdemeIadeEt(string islemNo, decimal tutar) => true;
        public string IslemDurumSorgula(string islemNo) => $"İşlem {islemNo} başarılı";

        public List<decimal> TaksitPlaniOlustur(decimal tutar, int taksitSayisi)
        {
            var plan = new List<decimal>();
            decimal taksit = (tutar * (1 + TaksitFaizOrani / 100)) / taksitSayisi;
            for (int i = 0; i < taksitSayisi; i++) plan.Add(Math.Round(taksit, 2));
            return plan;
        }

        public string DogrulamaKoduGonder(string tel) { var kod = new Random().Next(100000, 999999).ToString(); Console.WriteLine($"Kod {tel}'a: {kod}"); return kod; }
        public bool DogrulamaYap(string kod) { Console.WriteLine($"Kod {kod} doğrulandı"); return true; }
    }

    class BankaTransferi : IOdemeYontemi
    {
        public string YontemAdi => "Banka Transferi";
        public bool OdemeYap(decimal tutar, string iban) { Console.WriteLine($"{YontemAdi}: {tutar} TL → {iban}"); return true; }
        public bool OdemeIadeEt(string islemNo, decimal tutar) => true;
        public string IslemDurumSorgula(string islemNo) => $"Transfer {islemNo} işleniyor";
    }
    #endregion

    // ==========================================================
    #region 10. INTERFACE SEGREGATION PRINCIPLE (ISP)
    // ----------------------------------------------------------
    // KÖTÜ: Şişkin interface
    // interface IIsci { void Calis(); void MolaVer(); void RaporYaz(); void ToplantiYap(); void PersonelYonet(); }

    // İYİ: Küçük, odaklanmış interface'ler
    interface ICalisan { void Calis(); void MolaVer(); }
    interface IRaporlayan { void RaporYaz(); }
    interface IToplantiKatilimcisi { void ToplantiYap(); }
    interface IYonetici { void PersonelYonet(); }

    class IsciPersonel : ICalisan
    {
        public void Calis() => Console.WriteLine("İşçi çalışıyor");
        public void MolaVer() => Console.WriteLine("Mola veriyor");
    }

    class Mudur : ICalisan, IRaporlayan, IToplantiKatilimcisi, IYonetici
    {
        public void Calis() => Console.WriteLine("Müdür çalışıyor");
        public void MolaVer() => Console.WriteLine("Mola");
        public void RaporYaz() => Console.WriteLine("Yönetim raporu");
        public void ToplantiYap() => Console.WriteLine("Toplantı yönetiyor");
        public void PersonelYonet() => Console.WriteLine("Personel yönetiyor");
    }
    #endregion

    // ==========================================================
    #region 11. ÖNEMLİ NOKTALAR
    // ----------------------------------------------------------
    // Interface Özellikleri:
    // • Sadece imza (C# 8 öncesi)
    // • Çoklu implementasyon
    // • Constructor YOK
    // • Field YOK (property VAR)
    // • Access modifier YOK (her şey public)

    // Ne Zaman Kullanılır?
    // • Bağımsız sınıflar aynı davranış
    // • Birden fazla kaynak
    // • Loose coupling
    // • Dependency Injection
    // • Unit test (mock)

    // Naming: I ile başlar → ILogger, IRepository
    // "CAN-DO" ilişkisi (yapabilir)

    // Interface vs Abstract Class:
    // • Interface → "CAN-DO"
    // • Abstract → "IS-A"
    #endregion

    // ==========================================================
    #region PRENSİP
    // ----------------------------------------------------------
    // "Sınıflar sadece ihtiyaç duyduğu interface'leri implement etmeli"
    // → Interface Segregation Principle (ISP)
    #endregion

    // ======================================================
}
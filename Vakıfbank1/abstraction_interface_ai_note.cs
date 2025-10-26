// ======================================================
// C# OOP – ABSTRACTION (Soyutlama) – TAM NOT DOSYASI
// ======================================================
// Bu dosya sadece not amaçlıdır. Çalıştırma gerektirmez.
// Visual Studio'da #region ile katlanabilir.

// ==========================================================
#region 1. ABSTRACTION NEDİR?
// ----------------------------------------------------------
// Karmaşık detayları gizleyip sadece gerekli özellikleri gösterme.
// Kullanıcı "NE" yapıldığını bilir, "NASIL" yapıldığını bilmez.
#endregion

// ==========================================================
#region 2. ABSTRACT CLASS (Soyut Sınıf)
// ----------------------------------------------------------
// - new ile örneklenemez
// - Abstract + normal + virtual metod içerebilir
// - Field, constructor, property tanımlanabilir
// - Tek kalıtım (inheritance)
// - IS-A ilişkisi → "… bir şeydir"

abstract class Veritabani
{
    public abstract void BaglantiAc();
    public abstract void BaglantiKapat();
    public abstract void VeriKaydet(string veri);

    public void LogYaz(string mesaj) => Console.WriteLine($"[LOG] {DateTime.Now}: {mesaj}");

    public virtual void HataYonet(Exception ex) => Console.WriteLine($"Hata: {ex.Message}");
}

class MySqlVt : Veritabani
{
    public override void BaglantiAc() => Console.WriteLine("MySQL bağlantısı açıldı");
    public override void BaglantiKapat() => Console.WriteLine("MySQL bağlantısı kapatıldı");
    public override void VeriKaydet(string veri) => Console.WriteLine($"MySQL'e kaydedildi: {veri}");
}

class PostgreVt : Veritabani
{
    public override void BaglantiAc() => Console.WriteLine("PostgreSQL bağlantısı açıldı");
    public override void BaglantiKapat() => Console.WriteLine("PostgreSQL bağlantısı kapatıldı");
    public override void VeriKaydet(string veri) => Console.WriteLine($"PostgreSQL'e kaydedildi: {veri}");
}
#endregion

// ==========================================================
#region 3. INTERFACE (Arayüz)
// ----------------------------------------------------------
// - Sadece imzalar (C# 8+ default implementation hariç)
// - new yapılamaz, field YOK, constructor YOK
// - Çoklu implementasyon
// - CAN-DO → "… yapabilir"

interface IOdeme
{
    void OdemeYap(decimal tutar);
    bool OdemeIptal(string islemNo);
    string IslemSorgula(string islemNo);
}

class KrediKartiOdeme : IOdeme
{
    public void OdemeYap(decimal tutar) => Console.WriteLine($"Kredi kartı ile {tutar} TL ödendi");
    public bool OdemeIptal(string islemNo) { Console.WriteLine($"{islemNo} iptal edildi"); return true; }
    public string IslemSorgula(string islemNo) => $"İşlem {islemNo} başarılı";
}

class HavaleOdeme : IOdeme
{
    public void OdemeYap(decimal tutar) => Console.WriteLine($"Havale ile {tutar} TL gönderildi");
    public bool OdemeIptal(string islemNo) { Console.WriteLine("Havale iptal edilemez"); return false; }
    public string IslemSorgula(string islemNo) => $"Havale {islemNo} işleniyor";
}
#endregion

// ==========================================================
#region 4. ABSTRACT CLASS vs INTERFACE
// ----------------------------------------------------------
// ABSTRACT CLASS
abstract class Arac
{
    protected string Marka;
    public Arac(string marka) => Marka = marka;
    public abstract void Calistir();
    public void BilgiGoster() => Console.WriteLine($"Marka: {Marka}");
}

// INTERFACE
interface ISuruleBilir { void Hizlan(); void Yavasla(); void Dur(); }
interface IYakitli { void YakitDoldur(int litre); int YakitSeviyesi { get; } }

// BİRLİKTE KULLANIM
class Otomobil : Arac, ISuruleBilir, IYakitli
{
    private int yakit;
    public Otomobil(string marka) : base(marka) { }
    public override void Calistir() => Console.WriteLine("Motor çalıştı");
    public void Hizlan() => Console.WriteLine("Hızlanıyor");
    public void Yavasla() => Console.WriteLine("Yavaşlıyor");
    public void Dur() => Console.WriteLine("Durdu");
    public void YakitDoldur(int litre) => yakit += litre;
    public int YakitSeviyesi => yakit;
}
#endregion

// ==========================================================
#region 5. ÇOKLU INTERFACE KULLANIMI
// ----------------------------------------------------------
interface IOkunabilir { string Oku(); }
interface IYazilabilir { void Yaz(string veri); }
interface ISilinebilir { void Sil(); }

class DosyaIslemleri : IOkunabilir, IYazilabilir, ISilinebilir
{
    private string dosyaAdi;
    public DosyaIslemleri(string dosyaAdi) => this.dosyaAdi = dosyaAdi;
    public string Oku() => $"{dosyaAdi} okundu";
    public void Yaz(string veri) => Console.WriteLine($"{dosyaAdi}'na yazıldı: {veri}");
    public void Sil() => Console.WriteLine($"{dosyaAdi} silindi");
}
#endregion

// ==========================================================
#region 6. ABSTRACT PROPERTY
// ----------------------------------------------------------
abstract class Urun
{
    public abstract string Isim { get; set; }
    public abstract decimal Fiyat { get; }
    public int StokMiktari { get; set; }
    public abstract decimal KdvHesapla();
    public virtual void BilgiGoster() => Console.WriteLine($"{Isim} - {Fiyat} TL");
}

class Kitap : Urun
{
    private string isim; private decimal fiyat;
    public override string Isim { get => isim; set => isim = value; }
    public override decimal Fiyat => fiyat;
    public string Yazar { get; set; }
    public Kitap(string isim, decimal fiyat, string yazar)
    { this.isim = isim; this.fiyat = fiyat; Yazar = yazar; }
    public override decimal KdvHesapla() => Fiyat * 0.08m;
    public override void BilgiGoster() { base.BilgiGoster(); Console.WriteLine($"Yazar: {Yazar}"); }
}
#endregion

// ==========================================================
#region 7. INTERFACE DEFAULT IMPLEMENTATION (C# 8+)
// ----------------------------------------------------------
interface ILogger
{
    void Log(string mesaj);
    void LogHata(string mesaj) => Log($"HATA: {mesaj}");
    void LogUyari(string mesaj) => Log($"UYARI: {mesaj}");
}

class KonsolLogger : ILogger
{
    public void Log(string mesaj) => Console.WriteLine(mesaj);
    // LogHata ve LogUyari varsayılan olarak kullanılır
}
#endregion

// ==========================================================
#region 8. PRATİK ÖRNEK: E-TİCARET ÖDEME SİSTEMİ
// ----------------------------------------------------------
abstract class OdemeYontemi
{
    public string IslemNo { get; protected set; } = Guid.NewGuid().ToString();
    public abstract bool OdemeYap(decimal tutar);
    public abstract string IslemDetayGetir();
    public void MakbuzYazdir()
    {
        Console.WriteLine("=== MAKBUZ ===");
        Console.WriteLine($"İşlem No: {IslemNo}");
        Console.WriteLine(IslemDetayGetir());
    }
    public virtual bool TaksitYap(decimal tutar, int taksitSayisi)
    {
        Console.WriteLine("Bu ödeme yöntemi taksit desteklemiyor");
        return false;
    }
}

class KrediKarti : OdemeYontemi
{
    public string KartNo { get; set; }
    public override bool OdemeYap(decimal tutar)
    { Console.WriteLine($"Kredi kartı ile {tutar} TL ödendi"); return true; }
    public override string IslemDetayGetir() => $"Kredi Kartı: ****{KartNo[^4..]}";
    public override bool TaksitYap(decimal tutar, int taksitSayisi)
    {
        decimal taksit = tutar / taksitSayisi;
        Console.WriteLine($"{taksitSayisi} taksit x {taksit} TL");
        return true;
    }
}
#endregion

// ==========================================================
#region 9. GERÇEK HAYAT ÖRNEĞİ: BİLDİRİM SİSTEMİ
// ----------------------------------------------------------
interface IBildirim
{
    void BildirimGonder(string kime, string mesaj);
    bool BildirimDurumuKontrol(string bildirimId);
}

class EmailBildirim : IBildirim
{
    public void BildirimGonder(string kime, string mesaj)
    { Console.WriteLine($"Email → {kime}: {mesaj}"); }
    public bool BildirimDurumuKontrol(string bildirimId) => true;
}

class BildirimServisi
{
    private readonly List<IBildirim> kanallar = new();
    public void Ekle(IBildirim kanal) => kanallar.Add(kanal);
    public void TumKanallaraGonder(string kime, string mesaj)
        => kanallar.ForEach(k => k.BildirimGonder(kime, mesaj));
}
#endregion

// ==========================================================
#region 10. NE ZAMAN KULLANILIR?
// ----------------------------------------------------------
// ABSTRACT CLASS:
// • Ortak kod paylaşımı
// • Constructor, field, property
// • IS-A ilişkisi

// INTERFACE:
// • Çoklu davranış
// • Bağımsız sınıflar aynı yetenek
// • CAN-DO ilişkisi
#endregion

// ==========================================================
#region 11. ÖNEMLİ NOKTALAR
// ----------------------------------------------------------
// - Abstract sınıftan new yapılamaz
// - Abstract metodun gövdesi olmaz → override zorunlu
// - Interface'de field YOK (C# 8 öncesi)
// - Tüm abstract üyeler türeyen sınıfta implement edilmeli
// - C# 8+ → interface default implementation
#endregion

// ==========================================================
#region PRENSİP
// ----------------------------------------------------------
// "Detayları gizle, sadece gerekli olanı göster"
#endregion

// ======================================================
// ============================================================
// C# OOP - Relationships (İlişkiler) - Notlar
// ============================================================

using System;
using System.Collections.Generic;
using System.Linq;

#region 1. OOP'de İlişki Türleri
/*
1. Association  (İlişkilendirme)
2. Aggregation  (Toplama)
3. Composition  (Bileşim)
4. Inheritance  (Kalıtım)
5. Dependency   (Bağımlılık)
*/
#endregion

#region 2. Association (İlişkilendirme) - Has-a / Uses-a
// İki sınıf birbirini tanır ama bağımsızdır.
class Ogretmen
{
    public string Ad { get; set; }
    public List<Ogrenci> Ogrenciler { get; set; } = new();

    public Ogretmen(string ad) => Ad = ad;

    public void OgrenciEkle(Ogrenci ogrenci)
    {
        Ogrenciler.Add(ogrenci);
        Console.WriteLine($"{Ad} öğretmen, {ogrenci.Ad} öğrenciyi ekledi");
    }

    public void DerseGir()
    {
        Console.WriteLine($"{Ad} derse girdi");
        foreach (var o in Ogrenciler) Console.WriteLine($"  - {o.Ad}");
    }
}

class Ogrenci
{
    public string Ad { get; set; }
    public int Numara { get; set; }

    public Ogrenci(string ad, int numara) { Ad = ad; Numara = numara; }
    public void DerseCalis() => Console.WriteLine($"{Ad} derse çalışıyor");
}
#endregion

#region 2.1 One-to-One Association
class Kisi
{
    public string Ad { get; set; }
    public Pasaport Pasaport { get; set; }

    public Kisi(string ad) => Ad = ad;

    public void PasaportAl(Pasaport pasaport)
    {
        Pasaport = pasaport;
        pasaport.Sahibi = this;
        Console.WriteLine($"{Ad} pasaport aldı: {pasaport.No}");
    }
}

class Pasaport
{
    public string No { get; set; }
    public DateTime GecerlilikTarihi { get; set; }
    public Kisi Sahibi { get; set; }

    public Pasaport(string no) { No = no; GecerlilikTarihi = DateTime.Now.AddYears(10); }
}
#endregion

#region 2.2 One-to-Many Association
class Yazar
{
    public string Ad { get; set; }
    public List<Kitap> Kitaplar { get; set; } = new();

    public Yazar(string ad) => Ad = ad;

    public void KitapYaz(Kitap kitap)
    {
        Kitaplar.Add(kitap);
        kitap.Yazar = this;
        Console.WriteLine($"{Ad}, '{kitap.Baslik}' kitabını yazdı");
    }
}

class Kitap
{
    public string Baslik { get; set; }
    public int SayfaSayisi { get; set; }
    public Yazar Yazar { get; set; }

    public Kitap(string baslik, int sayfaSayisi) { Baslik = baslik; SayfaSayisi = sayfaSayisi; }
}
#endregion

#region 2.3 Many-to-Many Association
class Ogrenci2
{
    public string Ad { get; set; }
    public List<Ders> Dersler { get; set; } = new();

    public Ogrenci2(string ad) => Ad = ad;

    public void DerseKayitOl(Ders ders)
    {
        if (!Dersler.Contains(ders))
        {
            Dersler.Add(ders);
            ders.OgrenciEkle(this);
            Console.WriteLine($"{Ad}, {ders.Ad} dersine kayıt oldu");
        }
    }
}

class Ders
{
    public string Ad { get; set; }
    public List<Ogrenci2> Ogrenciler { get; set; } = new();

    public Ders(string ad) => Ad = ad;

    public void OgrenciEkle(Ogrenci2 ogrenci)
    {
        if (!Ogrenciler.Contains(ogrenci)) Ogrenciler.Add(ogrenci);
    }
}
#endregion

#region 3. Aggregation (Toplama) - Zayıf sahiplik
// Parça, bütünden bağımsız var olabilir.
class Departman
{
    public string Ad { get; set; }
    public List<Calisan> Calisanlar { get; set; } = new();

    public Departman(string ad) => Ad = ad;

    public void CalisanEkle(Calisan calisan)
    {
        Calisanlar.Add(calisan);
        Console.WriteLine($"{calisan.Ad}, {Ad} departmanına eklendi");
    }

    public void CalisanCikar(Calisan calisan)
    {
        Calisanlar.Remove(calisan);
        Console.WriteLine($"{calisan.Ad}, {Ad} departmanından ayrıldı");
    }
}

class Calisan
{
    public string Ad { get; set; }
    public string Pozisyon { get; set; }

    public Calisan(string ad, string pozisyon) { Ad = ad; Pozisyon = pozisyon; }
    public void Calis() => Console.WriteLine($"{Ad} çalışıyor");
}
#endregion

#region 4. Composition (Bileşim) - Güçlü sahiplik
// Parça, bütün olmadan var olamaz.
class Ev
{
    public string Adres { get; set; }
    public List<Oda> Odalar { get; private set; } = new();

    public Ev(string adres)
    {
        Adres = adres;
        OdaEkle("Salon", 30);
        OdaEkle("Yatak Odası", 20);
        OdaEkle("Mutfak", 15);
        Console.WriteLine($"{Adres} adresi ile ev oluşturuldu");
    }

    private void OdaEkle(string isim, int alan) => Odalar.Add(new Oda(isim, alan, this));
}

class Oda
{
    public string Isim { get; private set; }
    public int Alan { get; private set; }
    private Ev ev;

    internal Oda(string isim, int alan, Ev ev)
    {
        Isim = isim; Alan = alan; this.ev = ev;
    }
}
#endregion

#region 5. Inheritance (Kalıtım) - IS-A
class Hayvan
{
    public string Isim { get; set; }
    public int Yas { get; set; }

    public Hayvan(string isim, int yas) { Isim = isim; Yas = yas; }

    public virtual void SesCikar() => Console.WriteLine($"{Isim} ses çıkarıyor");
    public void Yemek() => Console.WriteLine($"{Isim} yemek yiyor");
}

class Kopek : Hayvan
{
    public string Cins { get; set; }

    public Kopek(string isim, int yas, string cins) : base(isim, yas) => Cins = cins;

    public override void SesCikar() => Console.WriteLine($"{Isim} havlıyor: Hav hav!");
    public void Getir() => Console.WriteLine($"{Isim} getiriyor");
}
#endregion

#region 6. Dependency (Bağımlılık) - Çok zayıf
class EmailService
{
    public void EmailGonder(string kime, string mesaj) =>
        Console.WriteLine($"Email gönderildi: {kime} - {mesaj}");
}

class Siparis
{
    public int Id { get; set; }
    public string Urun { get; set; }
    public decimal Tutar { get; set; }

    // Dependency - parametre olarak kullanım
    public void SiparisiOnayla(EmailService emailService, string email)
    {
        Console.WriteLine($"Sipariş {Id} onaylandı");
        emailService.EmailGonder(email, $"{Urun} siparişiniz onaylandı");
    }
}
#endregion

#region 7. Dependency Injection (DI) Örneği
interface IBildirimService { void BildirimGonder(string kime, string mesaj); }

class EmailBildirim : IBildirimService
{
    public void BildirimGonder(string kime, string mesaj) =>
        Console.WriteLine($"Email: {kime} - {mesaj}");
}

class Siparis2
{
    private readonly IBildirimService _bildirim;

    public Siparis2(IBildirimService bildirim) => _bildirim = bildirim;

    public int Id { get; set; }
    public string Urun { get; set; }

    public void SiparisiOnayla(string iletisim)
    {
        Console.WriteLine($"Sipariş {Id} onaylandı");
        _bildirim.BildirimGonder(iletisim, $"{Urun} siparişiniz onaylandı");
    }
}
#endregion

#region 8. Tüm İlişkileri Tek Örnekte
class Universite2
{
    public string Ad { get; set; }

    // Composition
    public List<Fakulte> Fakulteler { get; private set; } = new();

    // Aggregation
    public List<Ogrenci4> Ogrenciler { get; set; } = new();

    public Universite2(string ad)
    {
        Ad = ad;
        Fakulteler.Add(new Fakulte("Mühendislik"));
        Fakulteler.Add(new Fakulte("Tıp"));
    }

    // Dependency
    public void LogYaz(ILogger logger, string mesaj) => logger.Log($"{Ad}: {mesaj}");
}

class Fakulte { public string Ad { get; private set; } internal Fakulte(string ad) => Ad = ad; }
class Ogrenci4 { public string Ad { get; set; } public string Bolum { get; set; } public Ogrenci4(string ad, string bolum) { Ad = ad; Bolum = bolum; } }
interface ILogger { void Log(string mesaj); }
class KonsolLogger : ILogger { public void Log(string mesaj) => Console.WriteLine($"[LOG] {mesaj}"); }
#endregion

#region 9. Pratik Örnek: E-Ticaret Sistemi
abstract class Urun
{
    public int Id { get; set; }
    public string Ad { get; set; }
    public decimal Fiyat { get; set; }
    public abstract decimal KdvHesapla();
}

class Elektronik : Urun
{
    public int GarantiSuresi { get; set; }
    public override decimal KdvHesapla() => Fiyat * 0.20m;
}

class Siparis3
{
    public int Id { get; set; }
    public DateTime Tarih { get; set; } = DateTime.Now;
    public List<SiparisKalem> Kalemler { get; private set; } = new();
    public Musteri Musteri { get; set; } // Association

    public Siparis3(int id, Musteri musteri) { Id = id; Musteri = musteri; }

    public void UrunEkle(Urun urun, int adet)
    {
        Kalemler.Add(new SiparisKalem(urun, adet));
        Console.WriteLine($"{urun.Ad} x{adet} sepete eklendi");
    }
}

class SiparisKalem
{
    public Urun Urun { get; private set; }
    public int Adet { get; private set; }
    internal SiparisKalem(Urun urun, int adet) { Urun = urun; Adet = adet; }
    public decimal AraToplam() => Urun.Fiyat * Adet;
}

class Musteri
{
    public int Id { get; set; }
    public string Ad { get; set; }
    public string Email { get; set; }
    public List<Adres> Adresler { get; set; } = new(); // Aggregation

    public Musteri(int id, string ad, string email) { Id = id; Ad = ad; Email = email; }
    public void AdresEkle(Adres adres) => Adresler.Add(adres);
}

class Adres
{
    public string Il { get; set; }
    public string Ilce { get; set; }
    public string Detay { get; set; }
    public Adres(string il, string ilce, string detay) { Il = il; Ilce = ilce; Detay = detay; }
    public override string ToString() => $"{Detay}, {Ilce}/{Il}";
}
#endregion

#region 10. İlişki Türleri Karşılaştırma Tablosu
/*
| İlişki        | Bağlılık | Yaşam Döngüsü | Örnek                |
|---------------|----------|---------------|----------------------|
| Association   | Zayıf    | Bağımsız      | Öğretmen-Öğrenci     |
| Aggregation   | Orta     | Bağımsız      | Departman-Çalışan    |
| Composition   | Güçlü    | Bağımlı       | Ev-Oda               |
| Inheritance   | Çok Güçlü| -             | Hayvan-Köpek         |
| Dependency    | Çok Zayıf| -             | Sipariş-EmailService |
*/
#endregion

#region 11. UML Gösterimi
/*
- Association   : ————
- Aggregation   : ———◇
- Composition   : ———◆
- Inheritance   : ———▷
- Dependency    : - - - >
*/
#endregion

#region 12. Seçim Kriterleri
/*
- Parça bütün olmadan var olabilir mi? → Aggregation
- Parça bütün olmadan var olamaz mı?   → Composition
- Sadece metod parametresi mi?          → Dependency
- IS-A ilişkisi var mı?                 → Inheritance
- Sadece birbirini tanıyor mu?          → Association
*/
#endregion
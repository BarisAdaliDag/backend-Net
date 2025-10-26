// ============================================================
// C# Generics (Jenerikler) - Notlar
// ============================================================

using System;
using System.Collections.Generic;
using System.Linq;

#region 1. Generics Nedir?
// Tip bağımsız (type-safe) sınıflar, metodlar ve koleksiyonlar oluşturmayı sağlar.
// Aynı kodu farklı tipler için tekrar yazmaya gerek kalmaz.
#endregion

#region 2. Neden Generics?
// Generics OLMADAN
class IntListe { private int[] dizi = new int[10]; public void Ekle(int v) { } public int Al(int i) => dizi[i]; }
class StringListe { private string[] dizi = new string[10]; public void Ekle(string v) { } public string Al(int i) => dizi[i]; }

// Generics İLE
class Liste<T>
{
    private T[] dizi = new T[10];
    private int index = 0;
    public void Ekle(T deger) => dizi[index++] = deger;
    public T Al(int i) => dizi[i];
}
#endregion

#region 3. Generic Class (Sınıf)
class Kutu<T>
{
    private T icerik;
    public void Koy(T deger) { icerik = deger; Console.WriteLine($"{deger} kutuya kondu"); }
    public T Cikar() { Console.WriteLine($"{icerik} kutudan çıkarıldı"); return icerik; }
    public void Goster() => Console.WriteLine($"Kutuda: {icerik} (Tip: {typeof(T).Name})");
}

// Çoklu tip parametreli
class Cift<TKey, TValue>
{
    public TKey Anahtar { get; set; }
    public TValue Deger { get; set; }
    public Cift(TKey a, TValue d) { Anahtar = a; Deger = d; }
    public void Goster() => Console.WriteLine($"Anahtar: {Anahtar}, Değer: {Deger}");
}
#endregion

#region 4. Generic Method (Metod)
class Yardimci
{
    public T IlkEleman<T>(T[] dizi) => dizi[0];
    public void Yazdir<T>(T deger) => Console.WriteLine($"Değer: {deger}, Tip: {typeof(T).Name}");
    public void DiziYazdir<T>(T[] dizi) { foreach (var i in dizi) Console.Write($"{i} "); Console.WriteLine(); }

    public TResult Donustur<TInput, TResult>(TInput input, Func<TInput, TResult> converter) => converter(input);

    public void Degistir<T>(ref T a, ref T b) { T t = a; a = b; b = t; }
}
#endregion

#region 5. Generic Constraints (Kısıtlamalar)
class ReferansTip<T> where T : class { public T Deger { get; set; } }
class DegerTip<T> where T : struct { public T Deger { get; set; } }

class YeniNesne<T> where T : new() { public T Olustur() => new T(); }

abstract class Hayvan { public abstract void SesCikar(); }
class Kopek : Hayvan { public override void SesCikar() => Console.WriteLine("Hav!"); }

class HayvanBarinagi<T> where T : Hayvan
{
    private List<T> hayvanlar = new List<T>();
    public void Ekle(T h) => hayvanlar.Add(h);
    public void HepsiniKonustur() => hayvanlar.ForEach(h => h.SesCikar());
}

interface IKaydedilebilir { void Kaydet(); }
class Veritabani<T> where T : IKaydedilebilir
{
    public void VeriKaydet(T e) { e.Kaydet(); Console.WriteLine("Veritabanına kaydedildi"); }
}

// Birden fazla kısıtlama
class CokKisitli<T> where T : class, IKaydedilebilir, new() { }
#endregion

#region 6. Generic Interface
interface IRepository<T> where T : class
{
    void Ekle(T entity);
    void Sil(int id);
    void Guncelle(T entity);
    T IdyeGoreGetir(int id);
    List<T> TumunuGetir();
}
#endregion

#region 7. Generic Base Repository Pattern
interface IEntity { int Id { get; set; } }

class BaseRepository<T> where T : class, IEntity, new()
{
    protected List<T> entities = new List<T>();
    public virtual void Ekle(T e) { entities.Add(e); Console.WriteLine($"{typeof(T).Name} eklendi: Id={e.Id}"); }
    public virtual void Sil(int id) { var e = entities.FirstOrDefault(x => x.Id == id); if (e != null) entities.Remove(e); }
    public virtual T IdyeGoreGetir(int id) => entities.FirstOrDefault(x => x.Id == id);
    public virtual List<T> TumunuGetir() => entities;
}
#endregion

#region 8. Pratik Örnek: Cache Sistemi
class Cache<TKey, TValue>
{
    private readonly Dictionary<TKey, CacheItem<TValue>> _cache = new();
    private readonly TimeSpan _sure;
    public Cache(TimeSpan sure) => _sure = sure;

    public void Ekle(TKey k, TValue v) => _cache[k] = new CacheItem<TValue> { Deger = v, EklenmeTarihi = DateTime.Now, GecerlilikSuresi = _sure };
    public TValue Al(TKey k)
    {
        if (!_cache.ContainsKey(k)) return default;
        var item = _cache[k];
        if (DateTime.Now - item.EklenmeTarihi > item.GecerlilikSuresi) { _cache.Remove(k); return default; }
        return item.Deger;
    }
}
class CacheItem<T> { public T Deger; public DateTime EklenmeTarihi; public TimeSpan GecerlilikSuresi; }
#endregion

#region 9. Pratik Örnek: Result Pattern
class Result<T>
{
    public bool Basarili { get; private set; }
    public T Deger { get; private set; }
    public string Hata { get; private set; }
    public List<string> Hatalar { get; private set; } = new();

    private Result() { }
    public static Result<T> Success(T d) => new() { Basarili = true, Deger = d };
    public static Result<T> Failure(string h) => new() { Basarili = false, Hata = h };
    public static Result<T> Failure(List<string> h) => new() { Basarili = false, Hatalar = h };
}
#endregion

#region ÖNEMLİ NOTLAR
/*
✅ Generics Faydaları:
   • Tip güvenliği (type safety)
   • Kod tekrarını önler
   • Boxing/unboxing'den kaçınır (performans)
   • Tekrar kullanılabilirlik

⚠️ Constraint Sırası:
   1. where T : class/struct
   2. where T : BaseClass
   3. where T : Interface
   4. where T : new()

Yaygın Kullanımlar:
   • List<T>, Dictionary<TKey,TValue>
   • Repository Pattern
   • Cache sistemleri
   • Result/Response pattern
   • Factory pattern

**Naming Convention:**
   • Tek tip: T
   • Anahtar-Değer: TKey, TValue
   • Input-Output: TInput, TOutput
   • Birden fazla: T1,T2,T3 veya anlamlı isimler
*/
#endregion
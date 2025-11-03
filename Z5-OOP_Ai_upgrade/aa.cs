using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Z5_OOP_Ai_upgrade
{
    internal class aa
    {
    }
}

C#'ta `FirstOrDefault()`, `LastOrDefault()`, `SingleOrDefault()` gibi LINQ metodları ve benzer "default" parametreli metodları kastediyorsanız, işte en çok kullanılanlar:

## LINQ Extension Metodları (Default Parametreli)

** Eleman Bulma:**
```csharp
// İlk elemanı döndürür, bulamazsa default değer (null, 0, false vb.)
list.FirstOrDefault();
list.FirstOrDefault(x => x.Age > 18);

// Son elemanı döndürür, bulamazsa default
list.LastOrDefault();
list.LastOrDefault(x => x.Name == "Ali");

// Tek bir eleman bekler, yoksa veya birden fazlaysa default
list.SingleOrDefault(x => x.Id == 5);

// Belirtilen elemanı döndürür, bulamazsa default
list.ElementAtOrDefault(3); // index 3'teki eleman
```

**Diğer Yaygın LINQ Metodları:**
```csharp
// Koşula uyan elemanları filtreler
list.Where(x => x.Age > 18);

// Her eleman için dönüşüm yapar
list.Select(x => x.Name);

// Sıralar
list.OrderBy(x => x.Name);
list.OrderByDescending(x => x.Age);

// Koşul kontrolü
list.Any(x => x.Age > 18);  // En az bir eleman var mı?
list.All(x => x.Age > 18);  // Tüm elemanlar koşulu sağlıyor mu?
list.Contains(item);         // Eleman listede var mı?

// Sayma ve toplama
list.Count();
list.Count(x => x.Age > 18);
list.Sum(x => x.Salary);
list.Average(x => x.Age);
list.Max(x => x.Score);
list.Min(x => x.Score);

// Atla ve al
list.Skip(5);      // İlk 5'i atla
list.Take(10);     // İlk 10'u al
```

## String Metodları (Default/Index Parametreli)

```csharp
// İlk bulduğu indeksi döndürür, bulamazsa -1
string text = "Merhaba";
text.IndexOf("a");           // 4
text.IndexOf("x");           // -1
text.LastIndexOf("a");       // 6

// Substring - belirtilen pozisyondan itibaren
text.Substring(3);           // "haba"
text.Substring(3, 2);        // "ha"

// Contains, StartsWith, EndsWith
text.Contains("hab");        // true
text.StartsWith("Mer");      // true
text.EndsWith("ba");         // true
```

## List Metodları (Index Parametreli)

```csharp
List<string> list = new List<string>();

// Index ile erişim
list[0];                     // İlk eleman
list[list.Count - 1];        // Son eleman

// Index ile ekleme/çıkarma
list.Insert(2, "yeni");      // Index 2'ye ekle
list.RemoveAt(3);            // Index 3'teki elemanı çıkar

// Arama
list.IndexOf("aranan");      // İlk bulduğu index, yoksa -1
list.LastIndexOf("aranan");  // Son bulduğu index
list.FindIndex(x => x.StartsWith("A")); // Koşula uyan ilk elemanın index'i
```

Bunlardan hangisini daha detaylı görmek istersiniz?


    Tabii! Database sorgularında kullanılan yapıları da ekleyeyim:

## Entity Framework / LINQ to Entities Sorguları

**Temel Sorgular: **
```csharp
// Tek kayıt bulma
database.FirstOrDefault(e => e.Id == id);
database.SingleOrDefault(e => e.Email == email);
database.LastOrDefault(e => e.CreatedDate < DateTime.Now);

// Tüm kayıtları getirme
database.ToList();
database.Where(e => e.IsActive).ToList();

// Sayfa bazlı sorgular
database.Skip(10).Take(20).ToList(); // Sayfalama için
```

**Gelişmiş Sorgular: **
```csharp
// Join işlemleri
var result = database.Users
    .Join(database.Orders,
          user => user.Id,
          order => order.UserId,
          (user, order) => new { user, order });

// Include - İlişkili tabloları getirme
database.Users
    .Include(u => u.Orders)
    .Include(u => u.Address)
    .FirstOrDefault(u => u.Id == id);

// Select - Sadece belirli kolonları getirme
database.Users
    .Select(u => new { u.Name, u.Email })
    .ToList();

// GroupBy - Gruplama
database.Orders
    .GroupBy(o => o.UserId)
    .Select(g => new { UserId = g.Key, Count = g.Count() });

// Any - Varlık kontrolü
bool exists = database.Users.Any(u => u.Email == email);

// Count - Sayma
int count = database.Users.Count(u => u.IsActive);
```

**Filtreleme ve Sıralama:**
```csharp
// Where - Filtreleme
database.Products
    .Where(p => p.Price > 100 && p.Stock > 0)
    .ToList();

// OrderBy - Sıralama
database.Products
    .OrderBy(p => p.Name)
    .ThenByDescending(p => p.Price)
    .ToList();

// Distinct - Tekil kayıtlar
database.Users
    .Select(u => u.City)
    .Distinct()
    .ToList();
```

**CRUD İşlemleri: **
```csharp
// Create - Ekleme
var newUser = new User { Name = "Ali", Email = "ali@test.com" };
database.Users.Add(newUser);
await database.SaveChangesAsync();

// Read - Okuma
var user = database.Users.Find(id); // Primary key ile bulma
var user2 = database.Users.FirstOrDefault(u => u.Id == id);

// Update - Güncelleme
var user = database.Users.Find(id);
if (user != null)
{
    user.Name = "Yeni İsim";
    database.SaveChanges();
}

// Delete - Silme
var user = database.Users.Find(id);
if (user != null)
{
    database.Users.Remove(user);
    database.SaveChanges();
}
```

**Asenkron İşlemler(Önerilen):**
```csharp
// Asenkron sorgular
await database.Users.FirstOrDefaultAsync(u => u.Id == id);
await database.Users.ToListAsync();
await database.Users.AnyAsync(u => u.Email == email);
await database.Users.CountAsync();

// Asenkron CRUD
await database.Users.AddAsync(newUser);
await database.SaveChangesAsync();
```

**Performans İpuçları: **
```csharp
// AsNoTracking - Sadece okuma için (daha hızlı)
database.Users
    .AsNoTracking()
    .Where(u => u.IsActive)
    .ToList();

// Find vs FirstOrDefault
database.Users.Find(id);              // Önce cache'e bakar, daha hızlı
database.Users.FirstOrDefault(u => u.Id == id); // Her zaman DB'ye gider

// Lazy Loading vs Eager Loading
database.Users.Include(u => u.Orders); // Eager Loading (hemen yükle)
// vs
user.Orders // Lazy Loading (ihtiyaç olunca yükle)
```

**Karmaşık Sorgular: **
```csharp
// Alt sorgu
var richUsers = database.Users
    .Where(u => database.Orders
        .Where(o => o.UserId == u.Id)
        .Sum(o => o.Total) > 10000)
    .ToList();

// Union - Birleştirme
var activeUsers = database.Users.Where(u => u.IsActive);
var premiumUsers = database.Users.Where(u => u.IsPremium);
var combined = activeUsers.Union(premiumUsers);

// Take - İlk N kayıt
database.Products
    .OrderByDescending(p => p.SalesCount)
    .Take(10) // En çok satan 10 ürün
    .ToList();
```

Belirli bir senaryoya göre daha detaylı örnek ister misiniz?
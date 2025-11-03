namespace yy3_claude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // ==============================================
    // BASE INFRASTRUCTURE (Mevcut yapınızdan)
    // ==============================================

    public interface IBaseEntity
    {
        Guid Id { get; }
        DateTime CreatedDate { get; }
        DateTime UpdatedAt { get; set; }
    }

    public abstract class BaseEntity : IBaseEntity
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTime CreatedDate { get; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

    // ==============================================
    // 1. INTERFACE - Sözleşme tanımları
    // ==============================================

    // Ödünç alınabilir materyaller için sözleşme
    public interface IBorrowable
    {
        bool IsAvailable { get; }
        void Borrow(string borrowerName);
        void Return();
        int GetBorrowDurationDays();
    }

    // Fiyatlandırılabilir ürünler için sözleşme
    public interface IPriceable
    {
        decimal Price { get; set; }
        decimal CalculateLateFee(int daysLate);
    }

    // ==============================================
    // 2. ABSTRACT CLASS - Ortak davranış şablonu
    // ==============================================

    // Kütüphane materyali için abstract base class
    public abstract class LibraryMaterial : BaseEntity, IBorrowable, IPriceable
    {
        // ENCAPSULATION - private field, public property
        private string _title;
        private bool _isAvailable = true;
        private string _currentBorrower;
        private DateTime? _borrowDate;

        // Public Properties (Encapsulation)
        public string Title
        {
            get => _title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Başlık boş olamaz");
                _title = value;
            }
        }

        public string Publisher { get; set; }
        public int PublicationYear { get; set; }
        public decimal Price { get; set; }

        // IBorrowable implementation
        public bool IsAvailable => _isAvailable;

        public virtual void Borrow(string borrowerName)
        {
            if (!_isAvailable)
                throw new InvalidOperationException($"{Title} zaten ödünç alınmış!");

            _isAvailable = false;
            _currentBorrower = borrowerName;
            _borrowDate = DateTime.UtcNow;
            Console.WriteLine($"✓ '{Title}' {borrowerName} tarafından ödünç alındı.");
        }

        public virtual void Return()
        {
            if (_isAvailable)
                throw new InvalidOperationException($"{Title} zaten kütüphanede!");

            var daysLate = GetDaysLate();
            _isAvailable = true;

            Console.WriteLine($"✓ '{Title}' iade edildi.");

            if (daysLate > 0)
            {
                var fee = CalculateLateFee(daysLate);
                Console.WriteLine($"  ⚠ {daysLate} gün gecikme - Ceza: {fee:C}");
            }

            _currentBorrower = null;
            _borrowDate = null;
        }

        // Abstract method - Alt sınıflar implemente etmeli
        public abstract int GetBorrowDurationDays();

        // Abstract method - Her materyal türü farklı ceza hesaplar
        public abstract decimal CalculateLateFee(int daysLate);

        // Protected helper method (sadece alt sınıflar erişebilir)
        protected int GetDaysLate()
        {
            if (_borrowDate == null) return 0;
            var totalDays = (DateTime.UtcNow - _borrowDate.Value).Days;
            var allowedDays = GetBorrowDurationDays();
            return Math.Max(0, totalDays - allowedDays);
        }

        // Virtual method - Alt sınıflar override edebilir
        public virtual string GetInfo()
        {
            return $"{GetType().Name}: {Title} ({PublicationYear}) - {(IsAvailable ? "Mevcut" : "Ödünç alınmış")}";
        }
    }

    // ==============================================
    // 3. INHERITANCE - Somut sınıflar
    // ==============================================

    // Kitap sınıfı - LibraryMaterial'dan türer
    public class Book : LibraryMaterial
    {
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int PageCount { get; set; }

        // Abstract metodun implementasyonu
        public override int GetBorrowDurationDays() => 21; // 3 hafta

        public override decimal CalculateLateFee(int daysLate)
        {
            return daysLate * 2.5m; // Günlük 2.5 TL
        }

        // Override - Metodu özelleştirme
        public override string GetInfo()
        {
            return $"📚 {base.GetInfo()}\n   Yazar: {Author}, Sayfa: {PageCount}";
        }
    }

    // Dergi sınıfı
    public class Magazine : LibraryMaterial
    {
        public int IssueNumber { get; set; }
        public string Category { get; set; }

        public override int GetBorrowDurationDays() => 7; // 1 hafta

        public override decimal CalculateLateFee(int daysLate)
        {
            return daysLate * 1.5m; // Günlük 1.5 TL
        }

        public override string GetInfo()
        {
            return $"📰 {base.GetInfo()}\n   Kategori: {Category}, Sayı: {IssueNumber}";
        }
    }

    // DVD sınıfı
    public class DVD : LibraryMaterial
    {
        public string Director { get; set; }
        public int DurationMinutes { get; set; }
        public string Genre { get; set; }

        public override int GetBorrowDurationDays() => 14; // 2 hafta

        public override decimal CalculateLateFee(int daysLate)
        {
            return daysLate * 5.0m; // Günlük 5 TL (daha pahalı)
        }

        // Borrow metodunu override ederek özel davranış ekleme
        public override void Borrow(string borrowerName)
        {
            base.Borrow(borrowerName);
            Console.WriteLine($"   ℹ DVD'yi zarar görmeden iade ediniz. Süre: {GetBorrowDurationDays()} gün");
        }

        public override string GetInfo()
        {
            return $"📀 {base.GetInfo()}\n   Yönetmen: {Director}, Tür: {Genre}, Süre: {DurationMinutes} dk";
        }
    }

    // ==============================================
    // 4. REPOSITORY PATTERN (Generic)
    // ==============================================

    public interface IGenericRepository<T> where T : class, IBaseEntity
    {
        T Get(Guid id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }

    public class GenericRepository<T> : IGenericRepository<T> where T : class, IBaseEntity
    {
        protected static readonly List<T> database = new();

        public void Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            database.Add(entity);
        }

        public void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            database.Remove(entity);
        }

        public T Get(Guid id) => database.FirstOrDefault(e => e.Id == id);

        public IEnumerable<T> GetAll() => database.AsReadOnly();

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            var index = database.FindIndex(e => e.Id == entity.Id);
            if (index != -1)
            {
                entity.UpdatedAt = DateTime.UtcNow;
                database[index] = entity;
            }
        }
    }

    // Özel Repository
    public interface ILibraryRepository : IGenericRepository<LibraryMaterial>
    {
        IEnumerable<LibraryMaterial> GetAvailableMaterials();
        IEnumerable<LibraryMaterial> GetBorrowedMaterials();
    }

    public class LibraryRepository : GenericRepository<LibraryMaterial>, ILibraryRepository
    {
        public IEnumerable<LibraryMaterial> GetAvailableMaterials()
        {
            return database.Where(m => m.IsAvailable).ToList();
        }

        public IEnumerable<LibraryMaterial> GetBorrowedMaterials()
        {
            return database.Where(m => !m.IsAvailable).ToList();
        }
    }

    // ==============================================
    // 5. KULLANIM ÖRNEĞİ
    // ==============================================

    public class Program
    {
        public static void Main()
        {
            ILibraryRepository library = new LibraryRepository();

            // Farklı türde materyaller oluştur (Polymorphism)
            var book1 = new Book
            {
                Title = "Suç ve Ceza",
                Author = "Dostoyevski",
                ISBN = "978-0-14-044913-0",
                PageCount = 671,
                Publisher = "İletişim",
                PublicationYear = 1866,
                Price = 45.50m
            };

            var magazine1 = new Magazine
            {
                Title = "National Geographic",
                Category = "Bilim",
                IssueNumber = 245,
                Publisher = "NatGeo",
                PublicationYear = 2024,
                Price = 25.00m
            };

            var dvd1 = new DVD
            {
                Title = "Inception",
                Director = "Christopher Nolan",
                DurationMinutes = 148,
                Genre = "Bilim-Kurgu",
                Publisher = "Warner Bros",
                PublicationYear = 2010,
                Price = 35.00m
            };

            // Kütüphaneye ekle
            library.Add(book1);
            library.Add(magazine1);
            library.Add(dvd1);

            Console.WriteLine("═══════════════════════════════════════════");
            Console.WriteLine("   KÜTÜPHANE YÖNETİM SİSTEMİ");
            Console.WriteLine("═══════════════════════════════════════════\n");

            // Tüm materyalleri listele (Polymorphism)
            Console.WriteLine("📋 Kütüphanedeki Tüm Materyaller:\n");
            foreach (var material in library.GetAll())
            {
                Console.WriteLine(material.GetInfo());
                Console.WriteLine($"   Fiyat: {material.Price:C}, Ödünç süresi: {material.GetBorrowDurationDays()} gün\n");
            }

            Console.WriteLine("\n═══════════════════════════════════════════\n");

            // Ödünç alma işlemleri
            Console.WriteLine("📤 ÖDÜNÇ ALMA İŞLEMLERİ:\n");
            book1.Borrow("Ahmet Yılmaz");
            magazine1.Borrow("Zeynep Kaya");
            dvd1.Borrow("Mehmet Demir");

            Console.WriteLine("\n═══════════════════════════════════════════\n");

            // Mevcut materyaller
            Console.WriteLine("✅ Mevcut Materyaller:\n");
            var available = library.GetAvailableMaterials();
            if (available.Any())
            {
                foreach (var m in available)
                    Console.WriteLine($"  • {m.Title}");
            }
            else
            {
                Console.WriteLine("  Şu anda mevcut materyal yok.");
            }

            Console.WriteLine("\n═══════════════════════════════════════════\n");

            // İade işlemleri (gecikme simülasyonu için tarih değiştirilemediğinden mesaj gösterimi)
            Console.WriteLine("📥 İADE İŞLEMLERİ:\n");
            book1.Return();
            magazine1.Return();
            dvd1.Return();

            Console.WriteLine("\n═══════════════════════════════════════════\n");

            // Encapsulation örneği - hatalı değer
            Console.WriteLine("🔒 ENCAPSULATION ÖRNEĞİ:\n");
            try
            {
                var book2 = new Book { Title = "" }; // Hata fırlatacak
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"✗ Hata yakalandı: {ex.Message}");
            }

            Console.WriteLine("\n═══════════════════════════════════════════");
            Console.WriteLine("OOP KAVRAMLARI ÖZET:");
            Console.WriteLine("═══════════════════════════════════════════");
            Console.WriteLine("✓ INTERFACE: IBorrowable, IPriceable");
            Console.WriteLine("✓ ABSTRACT CLASS: LibraryMaterial");
            Console.WriteLine("✓ INHERITANCE: Book, Magazine, DVD");
            Console.WriteLine("✓ ENCAPSULATION: private fields, property validation");
            Console.WriteLine("✓ POLYMORPHISM: GetInfo(), CalculateLateFee()");
            Console.WriteLine("✓ VIRTUAL/OVERRIDE: Metod özelleştirme");
            Console.WriteLine("═══════════════════════════════════════════");
        }
    }
}

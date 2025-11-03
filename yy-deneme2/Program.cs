namespace yy_deneme2
{
    // =========================================
    // KÜTÜPHANE YÖNETİM SİSTEMİ - TAM PROJE
    // =========================================
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    // -----------------------
    // 1. IBaseEntity + BaseEntity
    // -----------------------
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

    // -----------------------
    // 2. Exceptions
    // -----------------------
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }
    }

    public class AuthorizationException : Exception
    {
        public AuthorizationException(string message) : base(message) { }
    }

    // -----------------------
    // 3. Entities
    // -----------------------
    public class User : BaseEntity
    {
        private string _username;
        private string _password;
        private string _email;

        public string Username
        {
            get => _username;
            set => _username = ValidateUsername(value);
        }

        public string Password
        {
            get => _password;
            set => _password = ValidatePassword(value);
        }

        public string Email
        {
            get => _email;
            set => _email = ValidateEmail(value);
        }

        public string Role { get; set; } = "User"; // Admin / User

        public User(string username, string password, string email, string role = "User")
        {
            Username = username;
            Password = password;
            Email = email;
            Role = role;
        }

        private string ValidateUsername(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                throw new ValidationException("Kullanıcı adı en az 3 karakter olmalı.");
            return value.Trim();
        }

        private string ValidatePassword(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 6)
                throw new ValidationException("Şifre en az 6 karakter olmalı.");
            return value; // Gerçekte hashlenir
        }

        private string ValidateEmail(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ValidationException("Email boş olamaz.");
            if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase))
                throw new ValidationException("Geçersiz email formatı.");
            return value.ToLower().Trim();
        }

        public override string ToString()
            => $"[User] {Username} ({Email}) - Role: {Role}";
    }

    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsBorrowed { get; set; }
        public Guid? BorrowerId { get; set; }

        public Book(string title, string author)
        {
            Title = string.IsNullOrWhiteSpace(title) ? throw new ValidationException("Başlık boş olamaz.") : title.Trim();
            Author = string.IsNullOrWhiteSpace(author) ? throw new ValidationException("Yazar boş olamaz.") : author.Trim();
        }

        public override string ToString()
            => $"[Book] {Title} - {Author} {(IsBorrowed ? "(Kiralık)" : "(Müsait)")}";
    }

    public class BorrowHistory : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime BorrowDate { get; set; } = DateTime.UtcNow;
        public DateTime? ReturnDate { get; set; }

        public override string ToString()
            => $"[History] Kitap: {BookId:B} → Kullanıcı: {UserId:B} | {BorrowDate:yyyy-MM-dd} {(ReturnDate != null ? $"→ İade: {ReturnDate:yyyy-MM-dd}" : "")}";
    }

    // -----------------------
    // 4. Generic Repository
    // -----------------------
    public interface IGenericRepository<T> where T : class, IBaseEntity
    {
        T Get(Guid id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }

    public class GenericRepository<T> : IGenericRepository<T> where T : class, IBaseEntity, new()
    {
        private static readonly List<T> _db = new();

        public void Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _db.Add(entity);
        }

        public void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _db.Remove(entity);
        }

        public T Get(Guid id) => _db.FirstOrDefault(x => x.Id == id);

        public IEnumerable<T> GetAll() => _db.AsReadOnly();

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            var existing = _db.FirstOrDefault(x => x.Id == entity.Id);
            if (existing != null)
            {
                var index = _db.IndexOf(existing);
                entity.UpdatedAt = DateTime.UtcNow;
                _db[index] = entity;
            }
        }
    }

    // -----------------------
    // 5. Özel Repository: User
    // -----------------------
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetByUsername(string username);
    }

    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public User GetByUsername(string username)
        {
            return GetAll().FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }
    }

    // -----------------------
    // 6. Servisler
    // -----------------------
    public class AuthService
    {
        private readonly IUserRepository _userRepo;
        public User CurrentUser { get; private set; }

        public AuthService(IUserRepository userRepo) => _userRepo = userRepo;

        public void Register(string username, string password, string email, string role = "User")
        {
            if (_userRepo.GetByUsername(username) != null)
                throw new ValidationException("Bu kullanıcı adı zaten alınmış.");
            var user = new User(username, password, email, role);
            _userRepo.Add(user);
            Console.WriteLine("Kayıt başarılı!");
        }

        public void Login(string username, string password)
        {
            var user = _userRepo.GetByUsername(username);
            if (user == null || user.Password != password)
                throw new ValidationException("Geçersiz kullanıcı adı veya şifre.");
            CurrentUser = user;
            Console.WriteLine($"Hoş geldin, {user.Username}!");
        }

        public void Logout()
        {
            CurrentUser = null;
            Console.WriteLine("Çıkış yapıldı.");
        }
    }

    public class LibraryService
    {
        private readonly IGenericRepository<Book> _bookRepo;
        private readonly IGenericRepository<BorrowHistory> _historyRepo;
        private readonly AuthService _auth;

        public LibraryService(IGenericRepository<Book> bookRepo, IGenericRepository<BorrowHistory> historyRepo, AuthService auth)
        {
            _bookRepo = bookRepo;
            _historyRepo = historyRepo;
            _auth = auth;
        }

        private User CurrentUser => _auth.CurrentUser ?? throw new AuthorizationException("Giriş yapmalısınız.");

        public void AddBook(string title, string author)
        {
            if (CurrentUser.Role != "Admin")
                throw new AuthorizationException("Sadece admin kitap ekleyebilir.");
            _bookRepo.Add(new Book(title, author));
            Console.WriteLine("Kitap eklendi!");
        }

        public void BorrowBook(Guid bookId)
        {
            var book = _bookRepo.Get(bookId) ?? throw new ValidationException("Kitap bulunamadı.");
            if (book.IsBorrowed)
                throw new ValidationException("Bu kitap zaten kiralanmış.");
            book.IsBorrowed = true;
            book.BorrowerId = CurrentUser.Id;
            _bookRepo.Update(book);
            _historyRepo.Add(new BorrowHistory(CurrentUser.Id, bookId));
            Console.WriteLine("Kitap ödünç alındı!");
        }

        public void ReturnBook(Guid bookId)
        {
            var book = _bookRepo.Get(bookId) ?? throw new ValidationException("Kitap bulunamadı.");
            if (!book.IsBorrowed || book.BorrowerId != CurrentUser.Id)
                throw new ValidationException("Bu kitap size ait değil.");
            book.IsBorrowed = false;
            book.BorrowerId = null;
            _bookRepo.Update(book);

            var history = _historyRepo.GetAll()
                .LastOrDefault(h => h.BookId == bookId && h.UserId == CurrentUser.Id && h.ReturnDate == null);
            if (history != null)
            {
                history.ReturnDate = DateTime.UtcNow;
                _historyRepo.Update(history);
            }
            Console.WriteLine("Kitap iade edildi!");
        }

        public void ListBooks()
        {
            Console.WriteLine("\n=== KÜTÜPHANEDEKİ KİTAPLAR ===");
            foreach (var b in _bookRepo.GetAll())
                Console.WriteLine($"ID: {b.Id:B} → {b}");
        }

        public void ListMyHistory()
        {
            var history = _historyRepo.GetAll().Where(h => h.UserId == CurrentUser.Id);
            Console.WriteLine("\n=== KİRALAMA GEÇMİŞİNİZ ===");
            if (!history.Any())
                Console.WriteLine("Henüz ödünç alınmış kitap yok.");
            else
                foreach (var h in history)
                    Console.WriteLine(h);
        }
    }

    // -----------------------
    // 7. Program (Ana Menü)
    // -----------------------
    class Program
    {
        static void Main()
        {
            var userRepo = new UserRepository();
            GenericRepository<Book> bookRepo = new GenericRepository<Book>();
            var historyRepo = new GenericRepository<BorrowHistory>();

            var auth = new AuthService(userRepo);
            var library = new LibraryService(bookRepo, historyRepo, auth);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== KÜTÜPHANE YÖNETİM SİSTEMİ ===");
                Console.WriteLine(auth.CurrentUser != null ? $"Hoş geldin, {auth.CurrentUser.Username} ({auth.CurrentUser.Role})" : "Misafir");
                Console.WriteLine("1. Kayıt Ol");
                Console.WriteLine("2. Giriş Yap");
                Console.WriteLine("3. Çıkış Yap");
                Console.WriteLine("4. Kitap Ekle (Admin)");
                Console.WriteLine("5. Kitapları Listele");
                Console.WriteLine("6. Kitap Ödünç Al");
                Console.WriteLine("7. Kitap İade Et");
                Console.WriteLine("8. Kiralama Geçmişim");
                Console.WriteLine("9. Çıkış");
                Console.Write("Seçiminiz: ");

                string choice = Console.ReadLine()?.Trim();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Kullanıcı Adı: "); string un = Console.ReadLine();
                            Console.Write("Şifre: "); string pw = Console.ReadLine();
                            Console.Write("Email: "); string em = Console.ReadLine();
                            Console.Write("Rol (User/Admin): "); string rl = Console.ReadLine();
                            auth.Register(un, pw, em, rl);
                            break;

                        case "2":
                            Console.Write("Kullanıcı Adı: "); un = Console.ReadLine();
                            Console.Write("Şifre: "); pw = Console.ReadLine();
                            auth.Login(un, pw);
                            break;

                        case "3":
                            auth.Logout();
                            break;

                        case "4":
                            Console.Write("Kitap Başlığı: "); string title = Console.ReadLine();
                            Console.Write("Yazar: "); string author = Console.ReadLine();
                            library.AddBook(title, author);
                            break;

                        case "5":
                            library.ListBooks();
                            break;

                        case "6":
                            Console.Write("Ödünç Alınacak Kitap ID: ");
                            if (Guid.TryParse(Console.ReadLine(), out Guid bid))
                                library.BorrowBook(bid);
                            else
                                Console.WriteLine("Geçersiz ID!");
                            break;

                        case "7":
                            Console.Write("İade Edilecek Kitap ID: ");
                            if (Guid.TryParse(Console.ReadLine(), out bid))
                                library.ReturnBook(bid);
                            else
                                Console.WriteLine("Geçersiz ID!");
                            break;

                        case "8":
                            library.ListMyHistory();
                            break;

                        case "9":
                            Console.WriteLine("Güle güle!");
                            return;

                        default:
                            Console.WriteLine("Geçersiz seçim!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"HATA: {ex.Message}");
                }

                Console.WriteLine("\nDevam etmek için bir tuşa basın...");
                Console.ReadKey();
            }
        }
    }
}

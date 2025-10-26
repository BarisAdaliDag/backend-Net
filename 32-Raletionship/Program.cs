namespace _32_OOP_Relationship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Has-A
            //Sahiplik ilişkileri, bir nesnenin diğer bir nesneye sahip olduğu durumu ifade eder.

            Library library = new Library("Kadıköy Merkez Kütüphanesi")
            {
                Books = new List<Book>
                {
                    new Book("Kitap-1", new Author("Yazar-1", "TR")),
                    new Book("Kitap-2", new Author("Yazar-1", "TR")),
                    new Book("Kitap-3", new Author("Yazar-2", "TR")),
                    new Book("Kitap-4", new Author("Yazar-3", "TR")),
                }
            };

            Console.WriteLine(library);
            #endregion

            #region Is-A
            //Bir Türdür, nesneler arasında hiyerarşik bir ilişki kurar. Kalıtımı ifade eder.
            Developer dev1 = new Developer("Alice", 90000, new List<string> { "C#", "JAvaScript" });
            Developer dev2 = new Developer("Bob", 80000, new List<string> { "C#", "Python" });
            Developer dev3 = new Developer("Tom", 100000, new List<string> { "C#", "Sql" });

            Manager manager = new Manager("Carol", 15000);
            manager.AddToTeam(dev1);
            manager.AddToTeam(dev2);

            Console.WriteLine(manager);
            #endregion

            #region Use-A
            //Kullanır, bir nesnenin başka bir nesneyi kullanarak geçici bir ilişki kurduğu durum.
            Customer customer = new Customer("Ali", "ali@mail.com");
            Order order = new Order(101, customer, 355);

            PaymentProcessor processor = new PaymentProcessor("PayFast");

            order.ProccessPayment(processor);

            #endregion

            #region Is-Part-Of
            //Parça bütün ilişkisi, bir nesnenin diğer nesnenin ayrılmaz bir parçası olduğunu ifade eder.

            Engine engine = new Engine("V8", 450);
            MusicSystem musicSystem = new MusicSystem("ABC");

            Car car = new Car("BMW", engine);
            car.MusicSystem = musicSystem;

            car.StartCar();
            #endregion

            #region Project
            /*Bir üniversite yönetim sistemi tasarlıyoruz. Sistemde:
            is-a (Inheritance): Person sınıfı, Student ve Teacher sınıflarının üst sınıfıdır. Student, bir Persondır; Teacher da bir Persondır.
            has-a (Composition): Bir Department (Bölüm), bir veya daha fazla Course (Ders) içerir. Course, Teacher ve Student nesnelerine sahiptir.
            use-a (Dependency): UniversitySystem, veritabanına bağlanmak için bir DatabaseConnector kullanır.
            is-part-of (Aggregation ve Composition): Bir University, birden fazla Department içerir (aggregation). Bir Course, bir Departmentın ayrılmaz bir parçasıdır (composition).*/
            #endregion
        }
    }
}

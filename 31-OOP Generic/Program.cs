namespace _31_OOP_Generic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Box<int> intBox = new Box<int>();
            //intBox.AddItem(19);
            //Console.WriteLine(intBox.GetItem());

            //Box<Book> stringBox = new Box<Book>();
            //stringBox.AddItem("Hello");
            //Console.WriteLine(stringBox.GetItem());

            //Box<Developer> personBox = new Box<Developer>();
            //personBox.AddItem(new Developer());
            //Console.WriteLine(personBox.GetItem());

            //IRepository<string> repository = new Repository<string>();
            //ICollection<string> list = new List<string>();

            ElectronicProduct laptop = new ElectronicProduct("Laptop", 50000, 100, 2);
            ElectronicProduct phone = new ElectronicProduct("Phone", 150000, 150, 2);

            FoodProduct apple = new FoodProduct("Apple", 50, 1000);
            FoodProduct bread = new FoodProduct("Bread", 150, 1000);

            IInventoryManagement<ElectronicProduct> electronics = new InventoryManagement<ElectronicProduct>();
            electronics.Add(laptop);
            electronics.Add(phone);

            Console.WriteLine("Electronic Inventory List");
            foreach (var item in electronics.GetAll())
            {
                Console.WriteLine(item);
            }

            electronics.Decrease(laptop, 50);
            electronics.Increase(phone, 8);

            IInventoryManagement<FoodProduct> foods = new InventoryManagement<FoodProduct>();
            foods.Add(bread);
            foods.Add(apple);

            Console.WriteLine("Foods Inventory List");
            foreach (var item in foods.GetAll()) 
            {
                Console.WriteLine(item);
            }

            foods.Decrease(apple, 200);

            IInventoryManagement<CozmeticProduct> ınventoryManagement = new InventoryManagement<CozmeticProduct>();
        }
    }
    //class -> T referans tip olmalıdır.
    //struct -> T value tip olmalıdır
    //new -> parametresiz yapıcıya sahip olmalıdır.
    //MyClass -> MyClass sınıfından türemiş bir sınıf olmalıdır.
    //IMyInterface -> IMyInterface'den implement edilmiş bir sınıf olmalıdır.
    public class Box<T> where T : IMarker
    {
        private T item;

        public void AddItem(T value) 
        {
            item = value;
            
        }

        public T GetItem() 
        { 
            return item;
        }
    }

    public interface IRepository<T>
    { 
        void Add(T value);
        void Update(T value);
        T Get(int id);
        List<T> GetAll();
    }

    public class Repository<T> : IRepository<T>
    {
        public void Add(T value)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(T value)
        {
            throw new NotImplementedException();
        }
    }
    public interface IMarker 
    { 
    
    }

    public class Employee : IMarker
    {
        public string Name { get; set; }
    }

    public class Developer : IMarker
    { 
    
    }

    public class HR : IMarker 
    { 
    
    }

    public class Book 
    { 
    
    }

}

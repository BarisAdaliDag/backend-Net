namespace _31_OOP_Generic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Box<int>intBox = new Box<int>();
            //  intBox.AddItem(1);
            //  Console.WriteLine(intBox.GetIteam());


            //Box<string> stringBox = new Box<string>();
            //stringBox.AddItem("aaa");
            //Console.WriteLine(stringBox.GetIteam);
            ElectronicProduct laptop = new ElectronicProduct("laptop", 23, 100, 2);
            ElectronicProduct phone = new ElectronicProduct("phone", 23, 100, 2);

            FoodProduct apple = new FoodProduct("Apple", 50, 100);
            FoodProduct bread = new FoodProduct("bread", 50, 100);

            IInvertoryManagment<ElectronicProduct> electronic = new InventoryManagment<ElectronicProduct>();
            electronic.Add (laptop);
            electronic.Add (phone);
            Console.WriteLine("Electorinic Inventory List");
            foreach (var item in electronic.GetAll()) {
                Console.WriteLine(item);
            }
            electronic.Increase(laptop,30);
            electronic.Decrease(phone,3);
            Console.WriteLine("--------------------");

        


        }
    }

    //class ->T refetans tipli
    //struct ->T value tipli
    //new ->T parametresiz yapıcıya sahip olmalıdır.
    //MyClass -> MyClass sınıfından türetilmiş bir class olmalıdır.(Base Class verdiğinde child class kullanılır)
    // class yaptığında t type ı bunu sadece Class veya child class kullanabilir.Base Class verirsen.Child classlarıda kullanabilirsin.
    //interface -> T type  interface belirtirsen.Sadece interface implemente classlarda kullanabilirsin
    public class Box<T> where T : class 
    {
        private T item;
        public void  AddItem(T value)
        {
            item= value;
        }
        public T GetIteam()
        {
            return item;
        }

    }

    public interface IRepository<T>
    {
        void Add(T value);
        void Update(T value);
        T GetValue(int id);
        List<T> GetAll();
    }

    public class Kitap : IRepository<Kitap>
    {
        public void Add(Kitap value)
        {
            throw new NotImplementedException();
        }

        public List<Kitap> GetAll()
        {
            throw new NotImplementedException();
        }

        public Kitap GetValue(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Kitap value)
        {
            throw new NotImplementedException();
        }
    }


}



namespace _33_Linq
{
    class Program
    {
      

        static void Main(string[] args)
        {
            // ------------------- LINQ ÖRNEĞİ -------------------
            // LINQ (Language Integrated Query) – veri koleksiyonlarını sorgulamak için kullanılır.
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

            // Method Syntax (tercih edilen)
            List<int> filteredByMethod = numbers.Where(n => n > 2).ToList();

            // Query Syntax
            var filteredByQuery = (from n in numbers
                                   where n > 2
                                   select n).ToList();   // select numbers → select n

            Console.WriteLine("2'den büyük sayılar (Method Syntax):");
            foreach (var item in filteredByMethod)
            {
                Console.WriteLine(item);
            }

          
      

            // ------------------- DELEGATE ÖRNEĞİ -------------------
            // Delegate nesnesi oluşturup metodları ekliyoruz
            NumDelegate numDelegate = Sum;      // new NumDelegate(Sum) yerine kısa yol
            numDelegate += Subtract;           // Çoklu metod (multicast)

            Console.WriteLine("\nDelegate ile işlemler:");
            numDelegate(10, 5);                // Hem Sum hem Subtract çalışır



            //Action<int, int> action = Sum;
            //action += Subtract;
            //action(16, 2);

            Func<int, int, int> func = SumF;
            func += SubtractF;
            func += (a, b) => a * b;
            func += Bolme;

            func(5, 2);
            Console.WriteLine("*****************");
            func -= SubtractF;
            func(5, 2);

           //notlar var
        }

        // 1. Delegate tanımı (class dışına, aynı namespace içinde)
        public delegate void NumDelegate(int a, int b);


        public static void Sum(int a, int b)
        {
            Console.WriteLine($"Toplam: {a + b}");
        }
        public static int SumF(int a, int b)
        {
            return a + b;
        }

       
        public static void Subtract(int a, int b)
        {
            Console.WriteLine($"Fark: {a - b}");
        }
        public static int SubtractF(int a, int b)
        {
            return a - b;
        }
        public static int Bolme(int a, int b) => a / b;
    }
}
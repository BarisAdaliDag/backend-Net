namespace _33_2_Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>()
    {
        new Student{ Id= 1,Name = "ahmet",Age=29,City = "Istanbul",DepartmentId = 101},
        new Student{ Id= 2,Name = "mehmet",Age=29,City = "ankara",DepartmentId = 102},
        new Student{ Id= 3,Name = "ayse",Age=29,City = "izmir",DepartmentId = 103},
        new Student{ Id= 4,Name = "fatma",Age=29,City = "Istanbul",DepartmentId = 104},
    };

            List<Department> departments = new List<Department>
        {
            new Department { Id = 100, Name = "Yazılım Geliştirme" },
            new Department { Id = 200, Name = "İnsan Kaynakları" },
            new Department { Id = 300, Name = "Pazarlama" },

        };

            #region Where
            //Method Syntax -tercih edilen
            bool deneme(Student student) => student.Age > 20;
            var filteredStudents = students.Where(deneme);
            var filteredStudents1 = students.Where(s => s.Age > 20 && s.City == "Istanbul").ToList();
            var filteredStudent2 = students.Where(s => s.Age > 20).Where(s => s.City == "Istanbul").ToList();

            foreach (var student in filteredStudents1)
            {
                Console.WriteLine(student);
            }

            //QUery Sytaxt

            var filteredStudentQuery = from s in students where s.Age > 20 select s;

            var filteredStudentQuery1 = from s in students where s.Age > 20 && s.City == "Istanbul" select s;
            #endregion


            #region OrderBy
            var sortedStudents = students.OrderBy(students => students.Age).ToList();
            var sortedStudents1 = students.OrderBy(students => students.Age).ThenByDescending(x => x.Name);

            var sortedStudentQuery = from s in students orderby s.Name descending select s;
            #endregion
            #region GroupBy
            var groupedResult = students.GroupBy(s => s.City).ToList();
            foreach (var item in groupedResult)
            {
                Console.WriteLine(item.Key + " " + item.Count());
                Console.WriteLine("--------------");
                foreach (var student in item)
                {
                    Console.WriteLine(student);
                }
            }
            var groupedResultQuery =
     from s in students
     group s by s.City into cityGroup
     select cityGroup;
            #endregion

            #region Select
            Console.WriteLine("SELECT");
            var studentSelect = students.Select(s => new { Adi = s.Name, Sehir = s.City });
            foreach (var student in studentSelect)
            {
                Console.WriteLine(student.Sehir + " " + student.Adi);
            }
            var deneme1 = new { ID = 1, Name = "Alii" }; //Hizli nesne olusturma
            var deneme2 = new StudentDTO { Sehir = "Istanbul", Adi = "Alii" };
            var deneme3 = new StudentDTO { Sehir = "Istanbul", Adi = "Alii" };
            //deneme2.Sehir = "Ankara"; X HATA DTO init dolayi immutable yapida
            deneme2.Adi = "Veli";
            if (deneme2 == deneme3)
            {
                //referans tipli fakat string gibi esittir ile iki degeri kiyaslayabilirsin
                Console.WriteLine("Esit");
            }

            var selectResult = from s in students
                               select new
                               {
                                   Ad = s.Name,
                                   Şehir = s.City,
                                   Yaş = s.Age
                               };

            #endregion
            #region Join
            var joinedData = students.Join(departments,
                s => s.DepartmentId,
                d => d.Id,
                (s, d) => new { Adi = s.Name, Yasi = s.Age, Sehir = s.City, Bolum = s.DepartmentId }
                );

            var joinedDataQuery = from s in students
                                  join d in departments
                                  on s.DepartmentId equals d.Id
                                  select new
                                  {
                                      s = s,
                                      d = d, //ugrasmamak icin birakti
                                  };


            #endregion

            #region All
            bool allStudentsPassed = students.All(x => x.Age > 18);
            Console.WriteLine(allStudentsPassed);
            #endregion

            #region Any
            bool hasPassedStudent = students.Any(x => x.Age > 20);
            Console.WriteLine(hasPassedStudent);
            #endregion

            #region Average
            double averageAge = students.Average(x => x.Age);
            Console.WriteLine(averageAge);
            #endregion

            #region Count
            var totalStudents = students.Count(s => s.Age > 20);
            #endregion

            #region Max-Min
            var max = students.Max(s => s.Age);
            var min = students.Min(s => s.Age);
            #endregion

            #region Sum
            var sumOfAge = students.Sum(x => x.Age);

            var numOfAdults = students.Sum(s =>
            {
                if (s.Age > 18)
                    return 1;
                else
                    return 0;
            });
            #endregion
            #region Element-ElementOrDefault
            //Bir koleksiyon icinde belirli bir konumdaki ogeyi almak icin kullanilir.

            Student studentIndex = students.ElementAt(2);//hata olursa exeption gore hata dondurmen gerekir
            Student studentAtIndex = students.ElementAtOrDefault(12);
            Console.WriteLine("-----------------------------------------");

            Console.WriteLine(studentAtIndex);



            #endregion

            #region First-FirstOrDefault
            //Belirli bir kosulu saglayan saglayan ilk ogeyi bulmak icin kullanilir
            Student firstStudent = students.First(); //bulamazise exveption firlatir
            Student firstStudent1 = students.First(x => x.Age > 20);
            if(firstStudent1 != null) {
                Console.WriteLine(firstStudent1);
            }
            else { Console.WriteLine("Bulunamdi"); }


            #endregion

            #region Last-LastOrDefault
            Student lastStudent = students.Last(x => x.Age > 20);
            if (lastStudent != null)
            {
                Console.WriteLine(lastStudent);
            }
            else
            {
                Console.WriteLine("Bulunamadi");
            }
            #endregion
            #region Single-SingleOrDefault
            //Bir koleksiyon icersindeki belirli bir kosulu saglayan yalnizca bir ogeyi dondurur.
            //Kosulu saglayan birden fazla oge varsa hata firlatir.

            //1-Bulamazsa invalid 2- tek degerde getirir  3- birden fazla operation exception firlatir

            //tamamla
            #endregion

            #region Skip-SkipWhile
            //Belirli bir sayida ogeyi veya belirli bir kosulu atlamak icin kullanilir.
            var afterSkipping = students.Skip(2).ToList();
            var afterSkipping1 = students.OrderBy(x=>x.Age).SkipWhile(s=>s.Age < 19).ToList();
            foreach (var item in afterSkipping1)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region Take - TakeWhile
            // Belirli sayıda öğeyi veya belirli bir koşula kadar olan öğeleri almak için kullanılır.

            var firstTwo = students.Take(2).ToList(); // İlk 2 öğrenciyi alır
            var takeWhileUnder19 = students
                .OrderBy(x => x.Age)
                .TakeWhile(s => s.Age < 19) // Yaşı 19'dan küçük olduğu sürece öğrencileri alır
                .ToList();

            Console.WriteLine("=== Take ===");
            foreach (var item in firstTwo)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("=== TakeWhile ===");
            foreach (var item in takeWhileUnder19)
            {
                Console.WriteLine(item);
            }
            #endregion
            Console.WriteLine("Dinamik Expression");
            GetDataWheredIEnumerable(students, x => x.Age > 11);

            var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var query = from num in numbers
                        let squared = num * num// let degisekn tanimliyorsun sorgu icinde
                        where squared > 25
                        select new { originalNum = num, squareNum = squared };//Anonim class olustutrdu new ile
            foreach (var item in query)
            {
                Console.WriteLine($"Original Sayi {item.originalNum} Kareleri {item.squareNum}");
            }
        }
        public static void GetDataWheredIEnumerable(IEnumerable<Student> source,Func<Student,bool>whereExp =null)
            //Func<Student,bool>whereExp bu delegate buna baj
        {
            if(whereExp != null)
            {
                var newList = source.Where(whereExp);
                foreach (var student in newList)
                {
                    Console.WriteLine(student);
                }
            }
           
        }
    }
}
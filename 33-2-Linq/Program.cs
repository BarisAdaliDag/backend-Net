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
            var filteredStudents1 = students.Where(s => s.Age > 20 && s.City =="Istanbul").ToList();
            var filteredStudent2 = students.Where(s=> s.Age > 20).Where(s => s.City == "Istanbul").ToList();

            foreach (var student in filteredStudents1) {
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
            var groupedResult = students.GroupBy(s=>s.City).ToList();
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
            var studentSelect = students.Select(s => new  { Adi = s.Name, Sehir = s.City});
            foreach (var student in studentSelect)
            {
                Console.WriteLine(student.Sehir + " " + student.Adi);
            }
            var deneme1 = new { ID = 1, Name = "Alii" }; //Hizli nesne olusturma
            var deneme2 = new StudentDTO { Sehir = "Istanbul", Adi = "Alii" };
            var deneme3 = new StudentDTO { Sehir = "Istanbul", Adi = "Alii" };
            //deneme2.Sehir = "Ankara"; X HATA DTO init dolayi immutable yapida
            deneme2.Adi = "Veli";
            if(deneme2 == deneme3)
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

            #region All-Any
            bool allStudentsPassed = students.All(x => x.Age > 10);
            Console.WriteLine(allStudentsPassed); // bool true

            bool hasPassedStudent = students.Any(x => x.Age > 10);
            Console.WriteLine(hasPassedStudent); // bool true


            #endregion
            #region Average
            //devamina bak

            #endregion

            //count
            //minmax



        }
    }
}
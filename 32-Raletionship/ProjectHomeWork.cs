using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _32_Raletionship
{
    #region Project
    /*Bir üniversite yönetim sistemi tasarlıyoruz. Sistemde:
    is-a (Inheritance): Person sınıfı, Student ve Teacher sınıflarının üst sınıfıdır. Student, bir Persondır; Teacher da bir Persondır.
    has-a (Composition): Bir Department (Bölüm), bir veya daha fazla Course (Ders) içerir. Course, Teacher ve Student nesnelerine sahiptir.
    use-a (Dependency): UniversitySystem, veritabanına bağlanmak için bir DatabaseConnector kullanır.
    is-part-of (Aggregation ve Composition): Bir University, birden fazla Department içerir (aggregation). Bir Course, bir Departmentın ayrılmaz bir parçasıdır (composition).*/
    #endregion
    // Program.cs
    using System;
    using System.Collections.Generic;

    namespace UniversityManagement
    {
        internal class Program
        {
            //static void Main(string[] args)
            //{
            //    // DatabaseConnector (use-a)
            //    var db = new DatabaseConnector();

            //    // UniversitySystem (use-a)
            //    var system = new UniversitySystem(db);
            //    system.Initialize();

            //    // University (aggregation → Department)
            //    var university = new University("Boğaziçi Üniversitesi");

            //    // Department (composition → Course)
            //    var csDept = new Department("Bilgisayar Mühendisliği");
            //    var mathDept = new Department("Matematik");

            //    // Teacher (is-a Person)
            //    var teacher1 = new Teacher("Prof. Ahmet", 52, "Algoritmalar");
            //    var teacher2 = new Teacher("Doç. Ayşe", 45, "Lineer Cebir");

            //    // Course (composition → Teacher + Students)
            //    var algoCourse = new Course("Algoritma Tasarımı", teacher1);
            //    var linearCourse = new Course("Lineer Cebir", teacher2);

            //    // Student (is-a Person)
            //    var s1 = new Student("Ali", 20, 2019001);
            //    var s2 = new Student("Veli", 21, 2019002);
            //    var s3 = new Student("Zeynep", 19, 2019003);

            //    algoCourse.EnrollStudent(s1);
            //    algoCourse.EnrollStudent(s2);
            //    linearCourse.EnrollStudent(s2);
            //    linearCourse.EnrollStudent(s3);

            //    // Department'a Course ekle
            //    csDept.AddCourse(algoCourse);
            //    mathDept.AddCourse(linearCourse);

            //    // University'ye Department ekle
            //    university.AddDepartment(csDept);
            //    university.AddDepartment(mathDept);

            //    // Çıktı
            //    Console.WriteLine(university);
            //    Console.ReadLine();
            //}
        }

        #region ----- CLASSES -----

        public class Person
        {
            private static int _nextId = 1;

            public int Id { get; private set; }
            public string Name { get; set; }
            public int Age { get; set; }

            public Person(string name, int age)
            {
                Id = _nextId++;
                Name = name;
                Age = age;
            }

            public override string ToString() => $"[ID:{Id}] {Name}, {Age} yaş";
        }

        // ---------- IS-A ----------
        public class Student : Person
        {
            public int StudentNumber { get; set; }

            public Student(string name, int age, int studentNumber) : base(name, age)
            {
                StudentNumber = studentNumber;
            }

            public override string ToString() => $"{base.ToString()}, Öğrenci No: {StudentNumber}";
        }

        public class Teacher : Person
        {
            public string Subject { get; set; }

            public Teacher(string name, int age, string subject) : base(name, age)
            {
                Subject = subject;
            }

            public override string ToString() => $"{base.ToString()}, Ders: {Subject}";
        }

        // ---------- HAS-A (Composition) ----------
        public class Course
        {
            public string CourseName { get; set; }
            public Teacher CourseTeacher { get; set; }               // composition
            public List<Student> EnrolledStudents { get; private set; } = new();

            public Course(string courseName, Teacher teacher)
            {
                CourseName = courseName;
                CourseTeacher = teacher;
            }

            public void EnrollStudent(Student student) => EnrolledStudents.Add(student);

            public override string ToString()
            {
                var students = string.Join("\n\t\t", EnrolledStudents);
                return $"Ders: {CourseName}\n\tÖğretmen: {CourseTeacher}\n\tKayıtlı Öğrenciler:\n\t\t{students}";
            }
        }

        public class Department
        {
            public string DepartmentName { get; set; }
            public List<Course> Courses { get; private set; } = new();   // composition

            public Department(string departmentName) => DepartmentName = departmentName;

            public void AddCourse(Course course) => Courses.Add(course);

            public override string ToString()
            {
                var courses = string.Join("\n\t", Courses);
                return $"Bölüm: {DepartmentName}\n\tDersler:\n\t{courses}";
            }
        }

        // ---------- IS-PART-OF (Aggregation) ----------
        public class University
        {
            public string UniversityName { get; set; }
            public List<Department> Departments { get; private set; } = new(); // aggregation

            public University(string universityName) => UniversityName = universityName;

            public void AddDepartment(Department department) => Departments.Add(department);

            public override string ToString()
            {
                var depts = string.Join("\n", Departments);
                return $"=== {UniversityName} ===\n{depts}";
            }
        }

        // ---------- USE-A (Dependency) ----------
        public class DatabaseConnector
        {
            public void Connect() => Console.WriteLine("Database connected.");
        }

        public class UniversitySystem
        {
            private readonly DatabaseConnector _dbConnector;

            public UniversitySystem(DatabaseConnector dbConnector) => _dbConnector = dbConnector;

            public void Initialize()
            {
                _dbConnector.Connect();
                Console.WriteLine("University system initialized.\n");
            }
        }

        #endregion
    }
}
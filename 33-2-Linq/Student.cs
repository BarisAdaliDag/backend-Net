using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _33_2_Linq
{
    public class Student
    {
        public int Id { get; set; }
       public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set;}

        public int DepartmentId { get; set;}

        public override string ToString()
        {
            return $"ID: {Id}, Ad: {Name}, Yaş: {Age}, Şehir: {City}, Departman ID: {DepartmentId}";
        }

    }

}

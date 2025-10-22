using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25_OOP_Inheritance_Lab
{
    internal class Teacher : Person
    {
        public static int Id = 300;
        public string Branch { get; set; }
        public int WorkingYear { get; set; }

        public Teacher(string firstName, string lastName, string email, int workingYear,string branch) : base(firstName, lastName, email)
        {
          Id = Id++;
            WorkingYear = workingYear;
            Branch = branch;
        }
        public override string ToString()

        {
            string baseStr = base.ToString();
            return $"Id =  {Id}  {baseStr} Calisma suresi {WorkingYear} brans {Branch}";
        }


    }
}

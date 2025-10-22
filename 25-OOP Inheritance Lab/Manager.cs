using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25_OOP_Inheritance_Lab
{
    internal class Manager : Person
    {
        public static int Id = 600;
        public string Role { get; set; }//ENUM HALI sinavda yuksek puan verir
        public List<Teacher> Employee { get; set; }
        public Manager(string firstName, string lastName, string email,string role ,List<Teacher> employee) : base(firstName, lastName, email)
        {
            Role = role;
            Employee = employee;
            Id = Id++;
        }
        public override string ToString()
        {
            string baseStr = base.ToString();

            return $"Id =  {Id} {Role} {baseStr}  "; 
        }
    }
}

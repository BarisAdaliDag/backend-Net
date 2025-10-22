using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_OOP_PartialClass
{
    public partial class Employee
    {

     
        public string Position { get; set; }
            
        public string Salary { get; set; }


        //partial void OnNameChanged()
        //{
        //    Console.WriteLine("Isim degistirildi");
        //}
        public void DisplayWorkDetails()
        {
            Console.WriteLine($"Pozisyon { Position} ");
        }
       
    }
}

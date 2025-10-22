using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23_OOP_Inheritance
{  //this keyword ait oldugum sinifi temsil eder
    // base parent class temsil eder

    //constractor ctor tab tab
    //SINAVDA PROTECTED PARENTTE KULLAN
    public class MobilPhone : Phone
    {

        public bool HasCamera { get; set; }
        public bool IsTouched { get; set; }
       // private string _connectionType;
        public MobilPhone() {
            Console.WriteLine("child class Parametresiz");

            //   base._connectionType = this._connectionType; // seklinde kullanacaksin
           _connectionType = "3G";
        }
        public MobilPhone(string brand): base(brand)
        {

            _connectionType = "3G";
        }
        public string TakePhoto()
        {
            if(HasCamera)
            {
                return "Fotograf cekildi";
            }
            else
            {
                return "Fotograf cekmez";

            }
        }
        public override string Call()
        {
            //      return base.Call();

            return "Arama yapiliyor ... Cendere cendere";

        }

        public override string ToString()
        {
            return $"Marka : {Brand} ,Bağlantı{ConnectionType}, kamera {HasCamera}, Dokunmatik: {IsTouched}";
        }



    }
}

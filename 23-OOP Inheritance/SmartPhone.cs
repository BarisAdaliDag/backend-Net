using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23_OOP_Inheritance
{
    public sealed class SmartPhone:MobilPhone
    {
        public bool FrontCam { get; set; }
        public SmartPhone()
        {
            
        }
        public SmartPhone(String brand):base(brand) 
        {
            _connectionType = "5G";

        }
        public string DoVideoCall()
        {
            if (FrontCam)
            {
                return "Görüntülü arama gerçekleştiriyor.";
            }
            else
            {
                return "Görüntülü arama gerceklestirilmiyor.";
            }
        }

            public sealed override string Call()
        {
            return "Arama yapiliyor ... Mp3 muzik caliyor";
        }
        public new string Call1()
        {
            return "Arama yapiliyor ... Mp3 muzik caliyor";
        }
    }
    
}

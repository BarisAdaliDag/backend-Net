
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26_OOP_Abstraction
{
    internal class Muzisyen
    {
        public Muzisyen(string adi, string soyadi)
        {
            Adi = adi;
            Soyadi = soyadi;
        }

        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public MuzikAleti CaldigiEnsturman { get; set; }
    }
}

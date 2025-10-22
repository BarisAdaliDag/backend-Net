using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26_OOP_Abstraction
{
    internal class MuzikGurubu
    {
        public MuzikGurubu(string grupadi)
        {
            Grupadi = grupadi;

        }

        public string Grupadi { get; set; }
        public List<Muzisyen> Calgicilar { get; set; } = new List<Muzisyen>();


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28_interface
{
    internal class Forvet : IFutbolcu
    {
        public string Name { get; set; }
        public int Numarasi { get; set; }
        public int Pasgucu { get; set; }
        public int SutGucu { get; set; }
        public int KosuGucu { get; set; }

        public void Kos()
        {
            Console.WriteLine("Kosu basladi...");
        }

        public void PasAt()
        {
            Console.WriteLine("pas at...");
        }

        public void SutCek()
        {
            Console.WriteLine("pas at...");
        }


    }
}

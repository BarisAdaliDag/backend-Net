using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28_interface
{
    internal class Kaleci : IFutbolcu, IKaleci
    {
        public string Name { get ; set ; }
        public int Numarasi { get ; set ; }
        public int Pasgucu { get ; set ; }
        public int SutGucu { get ; set ; }
        public int KosuGucu { get ; set ; }

        public void Kos()
        {
            throw new NotImplementedException();
        }

        public void PasAt()
        {
            throw new NotImplementedException();
        }

        public void SutCek()
        {
            throw new NotImplementedException();
        }

        public void TopKurtar()
        {
            throw new NotImplementedException();
        }
    }
}

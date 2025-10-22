using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28_interface
{
    public interface IFutbolcu
    {
        string Name { get; set; }
        int Numarasi { get; set; }
        int Pasgucu { get; set; }
        int SutGucu { get; set; }
        int KosuGucu { get; set; }

        void PasAt();
       
        void SutCek();

        void Kos();
       



    }
}

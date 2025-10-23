using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30_BuildInterFace.Example_3
{
    public class OgrenciOrtalamaKarsilastirici : IComparer<Ogrenci>
    {
        public int Compare(Ogrenci? x, Ogrenci? y)
        {
            return 1;
        }
    }
}

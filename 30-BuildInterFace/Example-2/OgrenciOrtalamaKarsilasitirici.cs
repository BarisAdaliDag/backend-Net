using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30_OOP_BuiltInInterface.Example_2
{
    public class OgrenciOrtalamaKarsilasitirici : IComparer<Ogrenci>
    {
        public int Compare(Ogrenci? x, Ogrenci? y)
        {
            if (x == null || y == null)
                throw new ArgumentException("Karşılaştıraln nesneler null olamaz");

            return y.Ortalama.CompareTo(x.Ortalama);
        }
    }
}

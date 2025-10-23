using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30_BuildInterFace.Example_3
{
    public class Ogrenci : IComparable<Ogrenci>, IEquatable<Ogrenci>
    {
        public Ogrenci(string ad, double ortalama)
        {
            Ad = ad;
            Ortalama = ortalama;
        }

        public string Ad { get; set; }
        public double Ortalama { get; set; }

        public int CompareTo(Ogrenci? other)
        {
           if(other == null) return 1;

           return other.Ad.CompareTo(this.Ad);

            //0 ise esitter .pozitif ise buyuktur negatif ise kucuktur/
        }

        //public bool Equals(Ogrenci? other)
        //{
        //    if(other == null) return false;
        //    return this.Ad == other.Ad;
        //}

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            var ogrenci = (Ogrenci)obj;
            return this.Ad == ogrenci.Ad;
        }

        public override int GetHashCode()
        {
            return Ad.GetHashCode();
        }
    }
}

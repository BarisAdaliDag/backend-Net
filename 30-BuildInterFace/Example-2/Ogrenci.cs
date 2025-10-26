using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30_OOP_BuiltInInterface.Example_2
{
    public class Ogrenci : IComparable<Ogrenci>, IEquatable<Ogrenci>, ICloneable
    {
        public string Ad { get; set; }
        public double Ortalama { get; set; }

        public object Clone()
        {
            return new Ogrenci() { Ad = this.Ad, Ortalama = this.Ortalama };
        }

        public int CompareTo(Ogrenci? other)
        {
            if(other == null) return 1;

            //return string.Compare(this.Ad, other.Ad, Str);
            return other.Ad.CompareTo(this.Ad);

            //0 nesne eşittir. Pozitif ise büyüktür negatif ise küçüktür.
        }

        public bool Equals(Ogrenci? other)
        {
            if (other == null) return false;
            return this.Ad == other.Ad;
        }

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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31_OOP_Generic.example_1
{
    internal class Kitaplik : IEnumerable<Kitap>
   

      
    {

        private List<Kitap> kitaplar = new List<Kitap>();
        public void KitapEkle(Kitap kitap)
        {
            kitaplar.Add(kitap);
    }
     
        public IEnumerator<Kitap> GetEnumerator()
        {
            //koleksiyonun yenileyicisini kullanarak foreach icinde gezinme saglar
            foreach(var item in kitaplar)
            {
                yield return item;
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            //type-safe
            //todo:
            throw new NotImplementedException();
        }
    }
}

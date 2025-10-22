using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26_OOP_Abstraction
{
    //Abstract Class,Sadece base class olarak davranılmasını istediğiniz ve kendisinden instance 
    //çıkarılmasını istediğimiz durumlarda kullanılır.
    public abstract class MuzikAleti
    {
        private string marka;
        private string aciklama;

        protected MuzikAleti(string marka, string aciklama)
        {
            this.marka = marka;
            this.aciklama = aciklama;
        }

        public string Aciklama
        {
            get { return aciklama; }
            set { aciklama = value; }
        }


        public string Marka
        {
            get { return marka; }
            set { marka = value; }
        }

        public string BilgiVer()
        {
            return $" Marka : {Marka} Muzik Aleti {aciklama}";
        }
        public abstract string Cal();//abstract methodun govdesi olmaz

        /*
         * 1-Abstract method private olmaz
         * 2-Abstract methodlar sadece abstract classlarda  tanımlanabilir
         * 3-Abstract metot virtual tanımlanmaz.Doğal virtual'dır.
         * 4-Abstract metot static olarak tanımlanmaz
         */

    }
}

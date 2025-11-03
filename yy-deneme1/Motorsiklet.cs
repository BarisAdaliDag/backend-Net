using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yy_deneme1
{
    public class Motosiklet : Arac
    {
        private int _silindirHacmi;
        private static readonly int[] izinliCc = { 100, 250, 500, 1000 };

        public Motosiklet(string plaka, string marka, string model, int yil, int gunlukKira, int silindirHacmi)
            : base(plaka, marka, model, yil, gunlukKira)
        {
            SilindirHacmi = silindirHacmi;
        }

        public int SilindirHacmi
        {
            get => _silindirHacmi;
            set
            {
                if (!izinliCc.Contains(value))
                    throw new ValidationException("Silindir hacmi 100, 250, 500 veya 1000 cc olmalı.", "Silindir Hacmi");
                _silindirHacmi = value;
            }
        }

        public override string KiraBilgisi()
        {
            // TODO: Sen yaz 
            string durum = KiralandiMi ? $" (Kiralık: {KiralayanKisi})" : " (Müsait)";
            return $"[{Plaka}] Motosiklet: {Marka} {Model} ({Yil}) - {SilindirHacmi}cc - Günlük: {GunlukKiraBedeli} TL{durum}";
        }
    }
}

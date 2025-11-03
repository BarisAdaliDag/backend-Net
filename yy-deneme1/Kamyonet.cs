using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yy_deneme1
{
    public class Kamyonet : Arac
    {
        private int _yukKapasitesi;

        public Kamyonet(string plaka, string marka, string model, int yil, int gunlukKiraBedeli, int yukKapasitesi)
            : base(plaka, marka, model, yil, gunlukKiraBedeli)
        {
            YukKapasitesi = yukKapasitesi;
        }

        public int YukKapasitesi
        {
            get => _yukKapasitesi;
            set
            {
                if (value < 500 || value > 3000)
                    throw new ValidationException("Yük kapasitesi 500 ile 3000 kg arasında olmalı.", "Yük Kapasitesi");
                _yukKapasitesi = value;
            }
        }

        public override string KiraBilgisi()
        {
            string durum = KiralandiMi ? $" (Kiralık: {KiralayanKisi})" : " (Müsait)";
            return $"[{Plaka}] Kamyonet: {Marka} {Model} ({Yil}) - {YukKapasitesi}kg - Günlük: {GunlukKiraBedeli} TL{durum}";
        }
    }

}

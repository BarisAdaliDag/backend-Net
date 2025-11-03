using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yy_deneme1
{
    public class Otomobil : Arac
    {
        private int _yolcuSayisi;

        public Otomobil(string plaka, string marka, string model, int yil, int gunlukKiraBedeli, int yolcuSayisi)
            : base(plaka, marka, model, yil, gunlukKiraBedeli)
        {
            YolcuSayisi = yolcuSayisi; // set → validation çalışsın
        }

        public int YolcuSayisi
        {
            get => _yolcuSayisi;
            set
            {
                if (value < 2 || value > 7)
                    throw new ValidationException("Yolcu sayısı 2 ile 7 arasında olmalıdır.", "_yolcuSayisi");
                _yolcuSayisi = value;
            }
        }

        public override string KiraBilgisi()
        {
            string durum = KiralandiMi ? $" (Kiralık: {KiralayanKisi})" : " (Müsait)";
            return $"[{Plaka}] Otomobil: {Marka} {Model} ({Yil}) - {YolcuSayisi} Kişilik - Günlük: {GunlukKiraBedeli} TL{durum}";
        }
    }


}

using System.Text.RegularExpressions;


namespace yy_deneme1
{
    public abstract class Arac : IKiralanabilir
    {
        private string _plaka;
        private bool _kiralandiMi;
        private string _kiralayanKisi = string.Empty;

        protected Arac(string plaka, string marka, string model, int yil, int gunlukKiraBedeli)
        {
            Plaka = plaka;                    // set → validation
            Marka = ValidationHelper.ValidateNotEmpty(marka, "Marka");
            Model = ValidationHelper.ValidateNotEmpty(model, "Model");
            Yil = ValidationHelper.ValidateInt(yil.ToString(), "Yıl", 1886, 2026);
            GunlukKiraBedeli = ValidationHelper.ValidateInt(gunlukKiraBedeli.ToString(), "Günlük Kira Bedeli", 1, 10000);
        }

        public string Plaka
        {
            get => _plaka;
            set
            {
                var temizPlaka = ValidationHelper.ValidateNotEmpty(value, "Plaka").ToUpper().Replace(" ", "");
                if (!Regex.IsMatch(temizPlaka, @"^[0-9]{2}[A-Z]{1,3}[0-9]{3,4}$"))


                    throw new ValidationException("Plaka formatı hatalı! Örnek: 34ABC123", "Plaka");
                _plaka = temizPlaka;
            }
        }

        public string Marka { get; set; }
        public string Model { get; set; }
        public int Yil { get; set; }
        public int GunlukKiraBedeli { get; set; }

        public bool KiralandiMi => _kiralandiMi;
        public string KiralayanKisi => _kiralayanKisi;

        // IKiralanabilir implementasyonu
        public void Kirala(string kisi)
        {
            if (_kiralandiMi)
                throw new InvalidOperationException($"{Plaka} plakalı araç zaten kiralanmış.");
            _kiralayanKisi = ValidationHelper.ValidateNotEmpty(kisi, "Kiralayan Kişi");
            _kiralandiMi = true;
        }

        public void IadeEt()
        {
            if (!_kiralandiMi)
                throw new InvalidOperationException($"{Plaka} plakalı araç zaten kütüphanede.");
            _kiralandiMi = false;
            _kiralayanKisi = string.Empty;
        }

        // Her araç türü farklı bilgi dönsün
        public abstract string KiraBilgisi();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yy_deneme1
{
    internal class AracRepository : IAracRepository
    {
        private readonly List<Arac> _araclar = new();

        public void Ekle(Arac arac)
        {
            if (arac == null) throw new ArgumentNullException(nameof(arac));
            if (_araclar.Any(a => a.Plaka == arac.Plaka))
                throw new ValidationException("Bu plaka zaten kayıtlı!", "Plaka");
            _araclar.Add(arac);
        }

        public Arac PlakayaGoreBul(string plaka)
        {
            return _araclar.FirstOrDefault(a => a.Plaka == plaka?.ToUpper().Replace(" ", ""));
        }

        public void Sil(Arac arac)
        {
            if (arac == null) throw new ArgumentNullException(nameof(arac));
            
            _araclar.Remove(arac);
        }

        public IEnumerable<Arac> TumAraclar() => _araclar.AsReadOnly();
    }
}

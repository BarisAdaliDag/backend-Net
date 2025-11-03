using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yy_deneme1
{
    public interface IAracRepository
    {
        void Ekle(Arac arac);
        void Sil(Arac arac);
        Arac PlakayaGoreBul(string plaka);
        IEnumerable<Arac> TumAraclar();
        // Bonus: int ToplamGunlukGelir();
    }
}

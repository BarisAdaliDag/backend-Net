using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yy_deneme1
{
    internal interface IKiralanabilir
    {
        void Kirala(string kisi);

        void IadeEt();

        bool KiralandiMi { get; }

        string KiraBilgisi();

    }
}

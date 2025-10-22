using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_Struct
{
    internal class Currency
    {
        public Currency(decimal amaount, string symbol)
        {
            Amaount = amaount;
            Symbol = symbol;
        }

        public decimal Amaount { get; set; }
        public string Symbol { get; set; }

        public string GetCurrency()
        {
            if (Symbol == "$")
                return $"{Amaount:F2}{Symbol}";

        }

    }
}

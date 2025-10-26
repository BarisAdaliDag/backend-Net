using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _29_OOP_InterfaceLab
{
    public class CreditCartPayment : BasePayment
    {
        public string CartNumber { get; set; }
        public string CVV { get; set; }
        public CreditCartPayment(decimal amount, string cartNumber, string cVV) : base(amount)
        {
            CartNumber = cartNumber;
            CVV = cVV;
        }

        public override void CancelPayment()
        {
            Console.WriteLine($"Kredi kartı ile yapılan {Amount} TL ödeme iptal edildi.");
        }

        public override void MakePayment()
        {
            Console.WriteLine($"Kredi kartı ile {Amount} TL ödeme yapıldı. Kart: {CartNumber}");
        }
    }
}

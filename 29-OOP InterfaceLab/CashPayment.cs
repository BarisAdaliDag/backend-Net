using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _29_OOP_InterfaceLab
{
    public class CashPayment : BasePayment
    {
        public CashPayment(decimal amount) : base(amount)
        {
        }

        public override void CancelPayment()
        {
            Console.WriteLine("Nakit Odeme Iptal Edildi");
        }

        public override void MakePayment()
        {
            Console.WriteLine($"Nakit {Amount} tl odeme gerceklesti");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _29_OOP_InterfaceLab
{
    public abstract class BasePayment : IPayment

    {

        // bunlarda cozumune gore kullanabilirsin
        //public void CancelPayment()
        //{
        //    throw new NotImplementedException();
        //}

        //public void MakePayment()
        //{
        //    throw new NotImplementedException();
        //}

        private decimal amount;

        protected BasePayment(decimal amount    )
        {
            this.amount = amount;
        }

        public decimal Amount
        {
            get { return amount; }
            set {
                if (value > 1)
                {
                    amount = value;
                }
                else
                    throw new ArgumentException("Odeme miktari 1 den kucuk olamaz");
            }
        }

        public abstract void CancelPayment();
        public abstract void MakePayment();
    }
}

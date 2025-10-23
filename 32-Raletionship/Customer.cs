using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _32_Raletionship
{
    public class Customer
    {
        public Customer(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Email}";
        }
    }

    public class Order
    {
        public int OrderId { get; set; }   // C# isimlendirme standardına göre: "Orderid" → "OrderId"
        public Customer Customer { get; set; }
        public decimal TotalAmount { get; set; }

        public override string ToString()
        {
            return $"Order ID: {OrderId}, Customer: {Customer}, Total: {TotalAmount:C}";
        }
    }

}

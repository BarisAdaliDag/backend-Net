using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _32_OOP_Relationship
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
            return $"{Name} ({Email})";
        }
    }

    public class Order
    {
        public Order(int orderId, Customer customer, decimal totalAmount)
        {
            OrderId = orderId;
            Customer = customer;
            TotalAmount = totalAmount;
        }

        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public decimal TotalAmount { get; set; }

        public void ProccessPayment(PaymentProcessor processor)
        {
            Console.WriteLine($"Processing payment for Order #{OrderId}...");
            processor.ProcessPayment(this);
        }

        public override string ToString()
        {
            return $"Order #{OrderId} for {Customer} - Total: {TotalAmount}";
        }
    }

    public class PaymentProcessor
    {
        public string ProviderName { get; set; }

        public PaymentProcessor(string providerName)
        {
            ProviderName = providerName;
        }

        //Ödeme işlemi
        public void ProcessPayment(Order order) 
        {
            Console.WriteLine($"Payment processed by {ProviderName} for {order}");
        }
    }
}

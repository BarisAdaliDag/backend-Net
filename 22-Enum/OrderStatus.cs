using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22_OOP_Enum
{
    public enum OrderStatus
    {
        /// <summary>
        /// 
        /// </summary>
        Pending = 101, 
        
        Processing, 
        Shipped = 200, Delivered, Cancelled
    }

    public class Order
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public OrderStatus Status { get; set; }

        public void Detail()
        {
            Console.WriteLine($"Order Id: {OrderId} Name: {Name} Status: {Status}");
        }
    }
}

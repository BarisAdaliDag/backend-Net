using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22_Enum
{/// <summary>
/// 
/// </summary>
    internal enum OrderStatus
    {
        Pending = 100,Processing=201,Shiped,Delivered,Cancelled
    }
    public class Order
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public void Detail()
        {
            Console.WriteLine($"Order Id: {OrderId} Name: { Name} Status {Status}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepencdencyInjection
{
    public interface IMessageSevice
    {
        void sendMessage(string message);
    }

    public class EmailMessegeService : IMessageSevice
    {
        public void sendMessage(string message)
        {
           
        }
    }
    public class SmsMessageService : IMessageSevice
    {
        public void sendMessage(string message)
        {
            Console.WriteLine($"Sms  {message} gonderildi");
        }
    }
}

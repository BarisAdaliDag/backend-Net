using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepencdencyInjection
{
    internal class NotificationSender
    {
        #region ConstractorInjection
        //private readonly IMessageSevice _messageService;

        //public NotificationSender(IMessageSevice messageService)
        //{
        //    _messageService = messageService;
        //}
        //public void Notify(string message)
        //{
        //    _messageService.sendMessage(message);
        //}
        #endregion


        //#region PropertiesInjection

        //public IMessageSevice _messageSevice { get; set; }
        //_messageSevice.sendMessage(message);
        //#endregion


        public void Notify(string message,IMessageSevice _messageSevice)
        {
        _messageSevice.sendMessage(message);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z3_OOP_Lab1
{
    public class Message
    {

        // Message(Id,Content,SenderId,RecevierId,CreatedDate)
        // Id : Sadece okunabilir olacak. Tip Guid olsun.
        // Content : En az 1 karakter uzunlugunda olmalidir. Assagi bir durumda herhangi bir karakter ile doldurunuz.
        // SenderId ve RecevierId : Bos gecilemez.
        // CreatedDate : Sadece okunabilir olsun. Mesajin olusturuldugu tarihi dondursun.

        public Guid Id { get; } = Guid.NewGuid();
        private String _content;
        private Guid _senderId;
        private Guid _receiverId;

        public Message(string content, Guid senderId, Guid receiverId)
        {
            _content = content;
            _senderId = senderId;
            _receiverId = receiverId;
        }

        public DateTime CreatedDate { get; } = DateTime.Now;

       


        public String Content
        {
            get { return _content; }
            set { if(value.Length < 1)
                {
                    throw new ArgumentException("Content en az 1 karakter uzunlugunda olmalidir.");
                }
                _content = value;

            }
        }
        public Guid SenderId
        {
            get => _senderId;
            set
            {
                if (value == Guid.Empty)
                    throw new ArgumentException("SenderId boş olamaz!");
                _senderId = value;
            }
        }

        public Guid ReceiverId
        {
            get => _receiverId;
            set
            {
                if (value == Guid.Empty)
                    throw new ArgumentException("ReceiverId boş olamaz!");
                _receiverId = value;
            }
        }
    }

}
}

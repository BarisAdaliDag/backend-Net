using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_OOP_Inheritance2.Exceptions_AI
{
    public class ValidationException : Exception
    {
        public string PropertyName { get; }
        public DateTime Timestamp { get; }

        public ValidationException(string message, string propertyName)
            : base($"[HATA] {message} | Tarih: {DateTime.Now:yyyy-MM-dd HH:mm:ss}")
        {
            PropertyName = propertyName;
            Timestamp = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Message} | Alan: {PropertyName}";
        }
    }
}

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

        public ValidationException(string message, string propertyName)
            : base($"{message} [{propertyName}] - {DateTime.Now:HH:mm:ss}")
        {
            PropertyName = propertyName;
        }
    }
}

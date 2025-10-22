using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_OOP_Inheritance2.Exceptions
{
    public class ValidationExceptions : Exception
    {
        public string PropertyName { get; private set; }
        public ValidationExceptions(string message,string PropertyName) : base(message+ "Date " + DateTime.Now) 
        {
          this.PropertyName = PropertyName;
        }
    }
}

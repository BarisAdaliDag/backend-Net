using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_Extension
{
    public static class ExceptionExtensions
    {
        public static string GetFriendlyMessage(this Exception ex)
        {
            return $"Error {ex.Message}\nDate: {DateTime.Now}";
        }
    }
}

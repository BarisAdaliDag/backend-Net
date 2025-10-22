using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_Extension
{
    public static class StringExtension
    {
        public static string ReverseString(this string str)
        {
            char[] chars = str.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        public static string CapitilizeString(this string str)
        {
            if (String.IsNullOrEmpty(str)) {
                throw new ArgumentException("ARGH!");
            }


            return char.ToUpper(str[0]) + String.Join("", str.Skip(1));
        }
    }
}

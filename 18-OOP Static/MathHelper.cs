using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_OOP_Static
{
    public static class MathHelper
    {

        public static double Pi => Math.PI;
        public static double CalculateCircleArea(int radius)
        {
            return Pi* radius * radius;
        }
    }
}

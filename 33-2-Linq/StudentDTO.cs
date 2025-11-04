using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _33_2_Linq
{
    // public class StudentDTO

    //{

    //    public string Adi { get; set; }
    //    public string Sehir { get; set; }
    //}
    public record StudentDTO
    {

        public string Adi { get; set; }
        public string Sehir { get; init; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_OOP_PartialClass
{
    public partial class Employeee
    {

        public string Name { get; set; }
        public int Age { get; set; }

        partial void OnNameChanged();
    }
}

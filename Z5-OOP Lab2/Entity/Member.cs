using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z5_OOP_Lab2.Entity
{
    public class Member : BaseEntity
    {
        public string username { get; set; }
        public string password { get; set; }
        public Member? member { get; set; }
    }
}

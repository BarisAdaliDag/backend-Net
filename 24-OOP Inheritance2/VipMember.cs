using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_OOP_Inheritance2
{
    internal class VipMember : BaseMember
    {
        public string Coach { get; set; }
        public VipMember(string firstName, string lastName, DateTime joinAt, string coach) : base(firstName, lastName, joinAt)
        {
            Coach = coach;
            _price = 7500;
        }


        public override string ToString()
        {
            return base.ToString() + "senelik ucret " + MembershipFree(12) + Coach;
        }
    }
}

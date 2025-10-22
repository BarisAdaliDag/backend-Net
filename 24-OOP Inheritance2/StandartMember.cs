using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_OOP_Inheritance2
{
    internal class StandartMember : BaseMember

    
    {

        public bool Kit { get; set; }
        public StandartMember(string firstName, string lastName, DateTime joinAt ) : base(firstName, lastName, joinAt)
        {
          
        }
        public override decimal MembershipFree(int mounth)
        {
            var price = base.MembershipFree(mounth);
           return Kit == true ? price + 3000 : price;
        }
        public override string ToString()
        {
            return base.ToString() + "senelik ucret " + MembershipFree(12);
        }

    }
}

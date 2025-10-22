using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_OOP_Static
{
    public class User
    {
        public static int TotalUsersId=0;
        public string Name { get; set; }
        public int Id { get; set; }

        public User() {
            TotalUsersId += 1;
                }
    
    }
}

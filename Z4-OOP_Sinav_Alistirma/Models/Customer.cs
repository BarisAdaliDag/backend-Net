using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z4_OOP_Sinav_Alistirma.Models
{
    public class Customer : User
    {


        public string LastName { get; set; } = null!;

        public string Username { get; set; } = null!;

      


        public override string ToString()
        {
            return $"{Id} : {FirstName} {LastName} {BirthDate} {Username}";
        }



    }
}

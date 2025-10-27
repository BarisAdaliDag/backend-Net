using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z4_OOP_Sinav_Alistirma.Models
{
    public class Seller : User
    {
        public Guid Id { get; set; }

        public string CompanyName { get; set; }

        public string UserName   { get; set; }
        public string Email { get; set; }
        public string CompanyAdress { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }


        public bool IsActive { get; set; }

   
        public DateTime BirthDate { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime UplatedDate { get; set; }
        public DateTime DeletedDate { get; set; }

    }
}

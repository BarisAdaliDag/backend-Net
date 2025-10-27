using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z4_OOP_Sinav_Alistirma.Models
{
    public abstract class User : IBaseUser
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = null!;

        public string Adress { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
        public bool IsActive { get; set; } = true;

        public string PhoneNumber { get; set; } = null!;
       
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime UplatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public DateTime BirthDate { get; set; }
    }
}

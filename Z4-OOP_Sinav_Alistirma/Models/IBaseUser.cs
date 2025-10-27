using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z4_OOP_Sinav_Alistirma.Models
{
    public interface IBaseUser
    {
        public Guid Id { get; set; }
        public DateTime UplatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool IsActive { get; set; }
    }
}

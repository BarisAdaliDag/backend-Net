using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z4_OOP_Sinav_Alistirma.Models;

namespace Z4_OOP_Sinav_Alistirma.DataAcccess
{
    public interface SellerDal : IGenericRepo<Seller>,ISellerDal
    {
    }
}

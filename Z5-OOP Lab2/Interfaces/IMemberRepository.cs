using ekim27_2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekim27_2.Interfaces
{
    public interface IMemberRepository : IGenericRepository<Member>
    {
        Member GetByUsername(string username);
    }
}

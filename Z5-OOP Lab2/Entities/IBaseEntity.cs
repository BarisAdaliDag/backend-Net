using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekim27_2.Entities
{
    public interface IBaseEntity
    {
        public Guid Id { get; }
        public DateTime CreatedDate { get; }
        public DateTime UpdatedAt { get; set; }
    }
}

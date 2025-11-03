using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekim27_2.Entities
{
    public abstract class BaseEntity : IBaseEntity
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTime CreatedDate { get; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }

    }
}

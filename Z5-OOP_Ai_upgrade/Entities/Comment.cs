using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekim27_2.Entities
{
    public class Comment : BaseEntity
    {
        public BaseUser User { get; set; }
        public Post Post { get; set; }
        public string Content { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} Content: {Content}";
        }
    }
}

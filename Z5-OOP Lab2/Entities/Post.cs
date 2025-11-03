using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekim27_2.Entities
{
    public class Post : BaseEntity
    {
        public Author Author { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public override string ToString()
        {
            return $"Id : {Id}, {Title} by {Author} \nBody: {Body}";
        }
    }
}

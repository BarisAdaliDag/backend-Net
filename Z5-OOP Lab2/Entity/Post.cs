using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z5_OOP_Lab2.Entity
{
    public class Post : BaseEntity
    {
        public Post(Author author)
        {
            Author = author;
        }

        public Category Category { get; set; }
        public Comment Comment { get; set; }

        public Author Author { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekim27_2.Entities
{
    public class Author : BaseUser
    {
        private List<Post> _posts;
        public string Title { get; set; }

        void AddPost(Post post)
        {
            _posts.Add(post);
        }


    }
}

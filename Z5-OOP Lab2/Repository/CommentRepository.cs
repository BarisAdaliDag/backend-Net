using ekim27_2.Entities;
using ekim27_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekim27_2.Repository
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public List<Comment> GetByPostId(Guid postId)
        {
            return database.Where(c => c.Post.Id == postId).ToList();
        }
    }
}

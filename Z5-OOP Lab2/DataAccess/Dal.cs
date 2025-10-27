using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z5_OOP_Lab2.DataAccess
{
    internal interface Dal
    {
      
    }
    public class AuthorDal : IGenericRepo<Author>, IAuthorDal
    {

    }
    public class CategoryDal : IGenericRepo<Category>, ICategoryDal
    {

    }
    public class CommentDal : IGenericRepo<Comment>, ICommentDal
    {

    }

    public class MemberDal : IGenericRepo<Member>, IMemberDal
    {

    }
    public class postDal : IGenericRepo<Post>, IPostDal
    {

    }
}

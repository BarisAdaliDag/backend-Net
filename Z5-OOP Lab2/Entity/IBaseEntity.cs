using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z5_OOP_Lab2.Entity
{
   public interface IBaseEntity
   {
       public DateTime CreatedDate { get; set; }
       public DateTime UpdatedDate { get; set; }
       public DateTime DeletedDate { get; set; }
       public bool IsActive { get; set; }
   }
}



//public class BaseEntity : IBaseEntity
//{
//    public Guid Id { get; set; }
//    public DateTime CreatedDate { get; set; }
//    public DateTime UpdatedDate { get; set; }
//    public DateTime DeletedDate { get; set; }
//    public bool IsActive { get; set; }
//}
//public class Member : BaseEntity
//{
//    public string UserName { get; set; } = null!;
//    public string Email { get; set; } = null!;
//    public string Password { get; set; } = null!;
//    public string PhoneNumber { get; set; } = null!;
//    // RP
//    public Author? Author { get; set; }
//}
//public class Author : BaseEntity
//{
//    public string FirstName { get; set; } = null!;
//    public string LastName { get; set; } = null!;
//    // RP
//    public Member Member { get; set; } = null!;

//}
//public class Post : BaseEntity
//{
//    public Guid CategoryId { get; set; }
//    public string Title { get; set; } = null!;
//    public string Content { get; set; } = null!;
//    // NP
//    public Category Category { get; set; } = null!;
//}
//public class Category : BaseEntity
//{
//    public string Name { get; set; } = null!;
//    public string Description { get; set; } = null!;
//    // RP
//    public List<Post>? Posts { get; set; }
//}
//public class Comment : BaseEntity
//{
//    public Guid PostId { get; set; }
//    public Guid MemberId { get; set; }
//    public string Content { get; set; } = null!;
//    // NP
//    public Post Post { get; set; } = null!;
//    public Member Member { get; set; } = null!;
//}
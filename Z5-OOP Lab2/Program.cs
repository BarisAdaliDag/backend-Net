using Z5_OOP_Lab2.DataAccess;
using Z5_OOP_Lab2.Entity;

namespace Z5_OOP_Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //IBaseEntity,BaseEntity,member,post,category,cooment
            // ICustomerDal customerDal = new CustomerDal();
            IMemberDal memberDal = new MemberDal();
            IAuthorDal authorDal = new AuthorDal();
        }
    }
}
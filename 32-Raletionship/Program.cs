using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _32_Raletionship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Has-A
            // Sahiplik Ilişkisi, bir nesnenin diğer bir nesneye sahip olduğu durumu ifade eder.

            Library library = new Library("kadikoy kutuphanesi")
            {
                Books = new List<Book>()
                {
                    new Book("Kitap-1", new Author("Yazar-1", "TR"))
                }
            };
            #endregion
        }

        #region Is-A

        #endregion


        

    }
}

using ekim27_2.Entities;
using ekim27_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekim27_2.Repository
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public Author GetByUsername(string username)
        {
            return database.FirstOrDefault(m => m.Username == username);
        }
    }
}

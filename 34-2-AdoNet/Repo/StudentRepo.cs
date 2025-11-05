using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _34_z_AdoNet.Repo
{
    public class StudentRepo : IStudentRepo
     
    {
      private  string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=StudentDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private SqlConnection conn;

        public StudentRepo()
        {

        }
        public void Add(Student student)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public Student GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Student student)
        {
            throw new NotImplementedException();
        }
    }
}

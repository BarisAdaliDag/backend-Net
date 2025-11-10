using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _34_AdoNET.Repo
{
    using _34_AdoNET.Models;
    using Microsoft.Data.SqlClient;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class StudentRepo : IStudentRepo
    {
        private string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=StudentDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private SqlConnection conn;

        public StudentRepo()
        {
            conn = new SqlConnection(connectionString);
        }

        public void Add(Student student)
        {
            conn.Open();
            string query = "INSERT INTO Student (Name, Age) VALUES (@Name, @Age)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Age", student.Age);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Delete(int id)
        {
            conn.Open();
            string query = "DELETE FROM Student WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<Student> GetAll()
        {
            List<Student> list = new List<Student>();
            conn.Open();
            string query = "SELECT * FROM Student";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Student()
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Age = (int)reader["Age"]
                });
            }

            reader.Close();
            conn.Close();
            return list;
        }

        public Student? GetById(int id)
        {
            Student student = null;
            conn.Open();
            string query = "SELECT * FROM Student WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                student = new Student()
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Age = (int)reader["Age"]
                };
            }

            reader.Close();
            conn.Close();
            return student;
        }

        public void Update(Student student)
        {
            conn.Open();
            string query = "UPDATE Student SET Name = @Name, Age = @Age WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.Add("@Age", SqlDbType.Int).Value = student.Age;             // int
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = student.Id;               // int (tip güvenli)
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
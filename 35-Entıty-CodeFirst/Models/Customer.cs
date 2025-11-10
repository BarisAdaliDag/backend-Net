using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _35_Entity_CodeFirst.Models
{
    public class Customer
    {
        private string _firstName;
        private string _lastName;

        public int Id { get; set; }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string FullName => _firstName + " " + _lastName;

        public string Email { get; set; }

        public string? Phone { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}

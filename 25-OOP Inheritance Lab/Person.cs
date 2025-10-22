using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25_OOP_Inheritance_Lab
{
   
    internal class Person
    {
		protected int id;
		private string _firstName;
		private string _lastName;
		private string _email;

        public Person( string firstName, string lastName, string email)
        {
            
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
        }

        public string Email
		{
			get { return _email; }
			set { _email = value; }
		}


		public string LastName
		{
			get { return _lastName; }
			set { _lastName = value; }
		}


		public string FirstName
		{
			get { return _firstName; }
			set { _firstName = value; }
		}

        public string FullName => _firstName + " " + _lastName;

        public int Id
		{
			get { return id; }
			set { id = value; }
		}

        public override string ToString()
        {
			return $"Name= {FirstName} LastName = {LastName} Email = {Email} ";
        }

    }
}

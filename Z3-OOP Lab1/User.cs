using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z3_OOP_Lab1
{
    public class User
    {
        // User(Id,Username,Password,Email,EmailConfirm,FirstName,LastName,CreatedDate)
        // Id : Sadece okunabilir olacak. Tip Guid olsun.
        // Username bos gecilemez, 3 ile 20 karakter arasinda olabilir. Eger fazla olursa kirpilsin, eksik kalirsa sol tarafi * sembolu ile doldurulsun.
        // Password en az 8 karakter uzunlugunda olmalidir. Assagi bir durumda herhangi bir karakter ile doldurunuz.
        // Email : Bos gecilemez olsun.
        // EmailConfirm : Sadece okunabilir olsun. Email ile ayni degeri dondursun.
        // FirstName ve LastName : Bos gecilemez.

        public Guid Id { get; } = Guid.NewGuid();
        private String _userName;
        private string _password;
        private string _email;
        private string _emailConfrim;
        private string _firstName;
        private string _lastName;

        public User(string userName, string password, string email, string emailConfrim, string firstName, string lastName)
        {
            _userName = userName;
            _password = password;
            _email = email;
            _emailConfrim = emailConfrim;
            _firstName = firstName;
            _lastName = lastName;
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("FirstName bos gecilemez");
                }
                _firstName = value;

            }

        }
        public string FirstName
        {
            get { return _firstName; }
            set {
            if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("FirstName bos gecilemez");
                }
                _firstName = value;

            }

        }


        public string EmailConfrim
        {
            get { return _emailConfrim; }
            set 
            {
                if(value != Email)
                {
                    throw new ArgumentException("Email ile EmailConfirm ayni olmalidir.");
                }
            }
        }



        public string Email
        {
            get { return _email; }
            set { 
            if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Email bos gecilemez");
                }
                _email = value;

            }
        }


        public string Password
        {
            get { return _password; }
            set
            {
                if(value.Length < 8)
                {
                    int empty = 8 - value.Length;
                    _password = value;
                    for (int i = 0; i < empty; i++)
                    {
                        _password += "1";
                    }
                  
                }
                else
                {
                    _password = value;
                }


            }
        }


        public String UserName
        {
            get { return _userName; }
            set 
            { 
                if (value.Length < 3)
                {
                    _userName = value.PadLeft(3, '*');
                }
                else if (value.Length > 20)
                {
                    _userName = value.Substring(0, 20);
                }
                else
                {
                    _userName = value;
                }

                 
            }
        }


       

    }
}

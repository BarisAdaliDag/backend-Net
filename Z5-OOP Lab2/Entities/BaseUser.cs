using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekim27_2.Entities
{
    public abstract class BaseUser : BaseEntity, IBaseUser
    {
        private string _password;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        public string Password
        {
            get => _password;
            set
            {
                if (value.Length >= 8)
                {
                    _password = value;
                    return;
                }

                throw new Exception("Şifre 8 karakterden uzun olmalıdır.");
            }
        }

        public override string ToString()
        {
            return $"Id: {Id} FirstName:{FirstName} LastName {LastName}";
        }
    }
}

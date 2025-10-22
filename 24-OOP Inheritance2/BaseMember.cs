using _24_OOP_Inheritance2.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_OOP_Inheritance2
{


    internal class BaseMember
    {

        private string _firstName;
        private string _lastName;
        private DateTime _joinAt;
        protected decimal _price = 500;

        protected BaseMember(string firstName, string lastName, DateTime joinAt)
        {
            _firstName = firstName;
            _lastName = lastName;
            this._joinAt = joinAt;
        }

        public DateTime JoinAt
        {
            get { return _joinAt; }
            set { _joinAt = DateValidation.CheckDate(value); }
        }



        public string LastName
        {
            get { return _lastName; }
            set {
            
            _lastName = CheckValidations.CheckValue(value);
            }
        }
        public string FirstName
        {
            get { return _firstName; }
            set {

              _firstName =  CheckValidations.CheckValue(value);
            }
        }
        public string FullName => _firstName + " " + _lastName;

        public virtual decimal MembershipFree(int mounth)
        {
            return _price * mounth;
        }
        public override string ToString()
        {
            return $"uye adi {FullName} kayit tarihi {JoinAt}  ucret { _price}";
        }

    }
}

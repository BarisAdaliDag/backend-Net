
using _24_OOP_Inheritance2.Validations_AI;
using System;

namespace _24_OOP_Inheritance2_AI
{
    internal class BaseMember
    {
        private string _firstName;
        private string _lastName;
        private DateTime _joinAt;
        protected decimal _price = 500m;

        protected BaseMember(string firstName, string lastName, DateTime joinAt)
        {
            FirstName = firstName;  // Property üzerinden validation
            LastName = lastName;
            JoinAt = joinAt;
        }

        public DateTime JoinAt
        {
            get => _joinAt;
            set => _joinAt = DateValidation.CheckJoinDate(value);
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName = CheckValidations.RequireNotEmpty(value, nameof(LastName));
        }

        public string FirstName
        {
            get => _firstName;
            set => _firstName = CheckValidations.RequireNotEmpty(value, nameof(FirstName));
        }

        public string FullName => $"{FirstName} {LastName}";

        public virtual decimal CalculateMembershipFee(int months)
        {
            if (months <= 0) throw new ArgumentException("Aylar sıfır veya negatif olamaz.", nameof(months));
            return _price * months;
        }

        public override string ToString()
        {
            return $"Üye: {FullName}, Kayıt: {JoinAt:dd.MM.yyyy}, Aylık: {_price:C}";
        }
    }
}
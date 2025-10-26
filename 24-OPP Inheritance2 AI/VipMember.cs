using _24_OOP_Inheritance2.Validations_AI;
using _24_OOP_Inheritance2_AI;

namespace _24_OOP_Inheritance2_AI
{
    internal class VipMember : BaseMember
    {
        public string Coach { get; set; }

        public VipMember(string firstName, string lastName, DateTime joinAt, string coach)
            : base(firstName, lastName, joinAt)
        {
            Coach = CheckValidations.RequireNotEmpty(coach, nameof(Coach));
            _price = 7500m;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Antrenör: {Coach}, Yıllık: {CalculateMembershipFee(12):C}";
        }
    }
}
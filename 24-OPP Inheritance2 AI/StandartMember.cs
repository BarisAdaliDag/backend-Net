using _24_OOP_Inheritance2_AI;

namespace _24_OOP_Inheritance2_AI
{
    internal class StandartMember : BaseMember
    {
        public bool Kit { get; set; }

        public StandartMember(string firstName, string lastName, DateTime joinAt)
            : base(firstName, lastName, joinAt) { }

        public override decimal CalculateMembershipFee(int months)
        {
            var baseFee = base.CalculateMembershipFee(months);
            return Kit ? baseFee + 3000m : baseFee;
        }

        public override string ToString()
        {
            var kitInfo = Kit ? " + Kit" : "";
            return $"{base.ToString()}{kitInfo}, Yıllık: {CalculateMembershipFee(12):C}";
        }
    }
}
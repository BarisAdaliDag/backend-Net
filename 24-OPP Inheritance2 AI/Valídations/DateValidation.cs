using _24_OOP_Inheritance2.Exceptions_AI;

namespace _24_OOP_Inheritance2.Validations_AI
{
    public static class DateValidation
    {
        public static DateTime CheckJoinDate(DateTime date)
        {
            if (date < DateTime.Today.AddYears(-5))
                throw new ValidationException("Kayıt tarihi çok eski olamaz.", nameof(date));

            return date;
        }
    }
}
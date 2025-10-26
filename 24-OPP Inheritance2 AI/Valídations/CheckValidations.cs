using _24_OOP_Inheritance2.Exceptions_AI;

namespace _24_OOP_Inheritance2.Validations_AI
{
    public static class CheckValidations
    {
        public static string RequireNotEmpty(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ValidationException("Bu alan boş olamaz.", propertyName);

            return value.Trim();
        }
    }
}
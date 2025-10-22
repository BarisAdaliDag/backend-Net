using _24_OOP_Inheritance2.Exceptions;


namespace _24_OOP_Inheritance2.Validations
{
    public static class CheckValidations
    {
        public static string CheckValue( string value)

        {
            if (!string.IsNullOrEmpty(value))
            {
                return value;
            }
            throw new ValidationExceptions("Bos olamaz", "value"); //TODO:  hata var 
           // throw new Exception("Bir hata oluştu!");
        }
        
    }
}

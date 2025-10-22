using _24_OOP_Inheritance2.Exceptions;


namespace _24_OOP_Inheritance2.Validations
{
    //Helper
    public static class DateValidation
    {

        public static DateTime CheckDate(DateTime date)
        {

            if (DateTime.Now <= date)
            {
                return date;
            }
            else
                throw new ValidationExceptions("Tarih alani dogrulanmadi", nameof(date));
        }

    }
}

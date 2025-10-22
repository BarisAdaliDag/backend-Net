namespace _27_OOP_AbstractionLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fatihSavings = new SavingsAccount("123", "Fatih Alkan");
            fatihSavings.Deposit(5000);
            fatihSavings.WithDraw(2000);
            fatihSavings.WithDraw(8000);
            Console.WriteLine(fatihSavings);
            Console.WriteLine("\n*************************");

            var fatihCurrents = new CurrentAccount("CA654", "Fatih Akin");
            fatihCurrents.Deposit(5000);
            fatihCurrents.WithDraw(7000);

        }
    }
}
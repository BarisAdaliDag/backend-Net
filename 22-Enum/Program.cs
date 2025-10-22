namespace _22_Enum
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Order order1 = new Order();
            order1.OrderId = 1;
            order1.Name= "Test";
           // order1.Status = OrderStatus.Delivered; hata var
            order1.Detail();

            Console.WriteLine();

        }
    }
}
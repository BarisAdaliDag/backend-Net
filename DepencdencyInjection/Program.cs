namespace DepencdencyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IMessageSevice messageSevice = new EmailMessegeService();
            NotificationSender sender = new NotificationSender(messageSevice);
            NotificationSender sender1 = new NotificationSender(messageSevice);
            sender1.Notify("Selam 1");
            NotificationSender sender2 = new NotificationSender(messageSevice);
            sender2.Notify("Selam 2");
        }
    }
}
namespace DependencyInversion
{
    //Adonet te entity adone kullanim durumu interface dayama
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}// 1️⃣ Soyutlama (interface)
public interface IMessageSender
{
    void Send(string message);
}

// 2️⃣ Alt seviye sınıflar soyutlamayı uygular
public class EmailSender : IMessageSender
{
    public void Send(string message)
    {
        Console.WriteLine("Email gönderildi: " + message);
    }
}

public class SmsSender : IMessageSender
{
    public void Send(string message)
    {
        Console.WriteLine("SMS gönderildi: " + message);
    }
}

// 3️⃣ Üst seviye sınıf soyutlamaya bağlı
public class NotificationService
{
    private readonly IMessageSender _messageSender;

    // Bağımlılık constructor üzerinden enjekte edilir (Dependency Injection)
    public NotificationService(IMessageSender messageSender)
    {
        _messageSender = messageSender;
    }

    public void Notify(string message)
    {
        _messageSender.Send(message);
    }
}

// 4️⃣ Kullanım
class Program
{
    static void Main()
    {
        IMessageSender emailSender = new EmailSender();
        IMessageSender smsSender = new SmsSender();

        NotificationService emailNotification = new NotificationService(emailSender);
        NotificationService smsNotification = new NotificationService(smsSender);

        emailNotification.Notify("Hoş geldiniz!");
        smsNotification.Notify("Kampanya başladı!");
    }
}

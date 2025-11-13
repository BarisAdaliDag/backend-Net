namespace IOCDependencyInjection.Services
{
    public class IShowDateTime
    {
        public DateTime? GetDateTime { get; }


    }
    public class ShowDateTime : IShowDateTime
    {
        public ShowDateTime()
        {
        }
    }
}

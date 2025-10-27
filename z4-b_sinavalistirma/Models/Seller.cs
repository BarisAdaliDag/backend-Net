namespace SinavAlistirma.Models
{
    public class Seller : User
    {
        public string CompanyName { get; set; } = null!;
        public string CompanyAddress { get; set; } = null!;
    }
}

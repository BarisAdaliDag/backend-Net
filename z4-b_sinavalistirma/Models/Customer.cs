namespace SinavAlistirma.Models
{
    public class Customer : User
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Address { get; set; } 
        public DateTime BirthDate { get; set; }

        public override string ToString()
        {
            return $"{Id} {FirstName} {LastName} {BirthDate} {Username}";
        }
    }
}
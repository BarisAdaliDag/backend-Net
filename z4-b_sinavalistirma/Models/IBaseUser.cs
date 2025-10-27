namespace SinavAlistirma.Models
{
    public interface IBaseUser
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool IsActive { get; set; } 
        public Guid Id { get;  }
    }
}

namespace _40_API_Entity.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public decimal  Price { get; set; }

        //Relations
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        //SoftDelete
        public bool IsDeleted { get; set; }

        //concurrency token (ETag uretmek icin kullanacagiz)
        public byte[] RowVersion { get; set; } = default!;

    }

}

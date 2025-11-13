namespace _40_API_Entity.Models.DTOs
{
    public record ProductDTO
    {
        public string Name { get; init; } = default!;
        public decimal Price { get; init; }
        public string? Description { get; init; }
        public int CategoryId { get; init; }
    }
}

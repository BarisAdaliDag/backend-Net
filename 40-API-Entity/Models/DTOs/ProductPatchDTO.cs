public record ProductPatchDTO
{

    public string? Name { get; init; }
    public decimal? Price { get; init; }
    public string? Description { get; init; }
    public int? CategoryId { get; init; }
}
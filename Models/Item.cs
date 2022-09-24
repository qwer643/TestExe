namespace TestExe.Models
{
    public record Item
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public DateTimeOffset CreatedDate { get; init; }

        public decimal Price { get; init; }
    }
}

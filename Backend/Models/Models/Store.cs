namespace Models.Models
{
    public class Store
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<StoreItem>? Items { get; set; } = [];
    }
}

namespace Models.Models
{
    public class Item
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required double Price { get; set; }
    }
}

namespace Models.Models
{
    public class StoreItem
    {
        public required int Id { get; set; }
        public required int Quantity { get; set; }
        public int? StoreId { get; set; }
        public Store? Store { get; set; }
        public int ItemId { get; set; }
        public Item? Item { get; set; }
    }
}

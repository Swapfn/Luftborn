namespace Models.Models
{
    public class InvoiceItem
    {
        public required int Id { get; set; }
        public required int Quantity { get; set; }
        public int? StoreItemId { get; set; }
        public StoreItem? Item { get; set; }
    }
}

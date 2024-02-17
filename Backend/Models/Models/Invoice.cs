namespace Models.Models
{
    public class Invoice
    {
        public required int Id { get; set; }
        public required DateTime Date { get; set; }
        public int StoreId { get; set; }
        public Store? Store { get; set; }
        public ICollection<InvoiceItem>? Items { get; set; } = [];
    }
}

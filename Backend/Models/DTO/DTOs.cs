namespace Models.Models
{
    public record StoreDTO(int Id, string Name, List<StoreItemDTO>? Items);
    public record StoreItemDTO(int Id, int Quantity, int? StoreId, int? ItemId, ItemDTO? Item);
    public record ItemDTO(int Id, string Name, string? Description, int Price);
    public record InvoiceDTO(int Id, DateTime Date, int? StoreId, InvoiceItemDTO? Item);
    public record InvoiceItemDTO(int Id, int Quantity, int? StoreItemId, StoreItemDTO? Item);
}

namespace Models.Models
{
    public record StoreDTO(int Id, int Name, List<StoreItemDTO>? Items);
    public record StoreItemDTO(int Id, int Quantity, int? StoreId, StoreDTO? Store, int? ItemId, ItemDTO? Item);
    public record ItemDTO(int Id, string Name, string? Description, int Price);
    public record InvoiceDTO(int Id, DateTime Date, int? StoreId, StoreDTO? Store, InvoiceItemDTO? Item);
    public record InvoiceItemDTO(int Id, int Quantity, int? StoreItemId, StoreItemDTO? Item);
}

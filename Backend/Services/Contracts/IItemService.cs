using Models.Models;

namespace Services.Contracts
{
    public interface IItemService
    {
        ICollection<ItemDTO> GetItems();
        (ICollection<ItemDTO> Items, int Count) GetItems(int pageNumber, int pageSize);
        ItemDTO GetItem(int id);
        ItemDTO AddItem(ItemDTO model);
        ItemDTO UpdateItem(ItemDTO model);
        void DeleteItem(int id);
    }
}

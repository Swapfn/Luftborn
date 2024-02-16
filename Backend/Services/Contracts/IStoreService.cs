using Models.Models;

namespace Services.Contracts
{
    public interface IStoreService
    {
        ICollection<StoreDTO> GetStores();
        StoreDTO GetStore(int id);
        StoreDTO AddStore(StoreDTO model);
        StoreDTO UpdateStore(StoreDTO model);
        void DeleteStore(int id);
    }
}

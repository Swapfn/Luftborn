using Data.Infrastructure;
using Models.Models;

namespace Data.Repositories.Contracts
{
    public interface IStoreRepository : IBaseRepository<Store>
    {
        Store Get(int id, string name);
    }
}

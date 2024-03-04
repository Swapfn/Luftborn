using Data.Infrastructure;
using Data.Repositories.Contracts;
using Data.Repositories.Specification;
using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace Data.Repositories.Repositories
{
    public class StoreRepository(ApplicationDbContext context) : BaseRepository<Store>(context), IStoreRepository
    {
        public override Store? GetById(int id)
        {
            return context.Stores.Where(c => c.Id == id)?.Include(c => c.Items).ThenInclude(c => c.Item).AsNoTracking().FirstOrDefault();
        }
    }
    public class GetStoreByIdSpecifications : Specification<Store>
    {
        public GetStoreByIdSpecifications(int id) : base(store => store.Id == id)
        {
            AddInclude(store => store.Items);
        }
    }
    public class GetStoreByNameSpecifications : Specification<Store>
    {
        public GetStoreByNameSpecifications(string name) : base(store => store.Name == name)
        {
            AddInclude(store => store.Items);
        }
    }
}

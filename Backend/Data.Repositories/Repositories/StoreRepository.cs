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

        public Store Get(int id, string name)
        {
            var x = QuerySpecification(new AndSpecification<Store>(new GetStoreByIdSpecifications(id), new GetStoreByNameSpecifications(name))).FirstOrDefault();
            var y = QuerySpecification(new OrSpecification<Store>(new GetStoreByIdSpecifications(2), new GetStoreByNameSpecifications("string1"))).FirstOrDefault();
            var z = QuerySpecification(new NotSpecification<Store>(new GetStoreByIdSpecifications(1))).FirstOrDefault();

            return x;
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

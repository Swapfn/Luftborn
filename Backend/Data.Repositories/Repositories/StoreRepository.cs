using Data.Infrastructure;
using Data.Repositories.Contracts;
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
}

using Data.Infrastructure;
using Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace Data.Repositories.Repositories
{
    public class ItemRepository(ApplicationDbContext context) : BaseRepository<Item>(context), IItemRepository
    {
        public override Item? GetById(int id)
        {
            return context.Items.Where(c => c.Id == id).AsNoTracking().FirstOrDefault();
        }
    }
}

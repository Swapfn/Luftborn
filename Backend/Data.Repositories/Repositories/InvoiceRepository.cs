using Data.Infrastructure;
using Data.Repositories.Contracts;
using Models.Models;

namespace Data.Repositories.Repositories
{
    public class InvoiceRepository(ApplicationDbContext context) : BaseRepository<Invoice>(context), IInvoiceRepository
    {
    }
}

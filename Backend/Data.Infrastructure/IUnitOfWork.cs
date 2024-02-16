namespace Data.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        bool SaveChanges();
    }
}

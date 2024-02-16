namespace Data.Infrastructure
{
    public interface IBaseRepository<T> where T : class
    {
        T Add(T entity);

        T Update(T entity);

        void Delete(T entity);

        T? GetById(int id);

        IEnumerable<T> GetAll();
    }
}

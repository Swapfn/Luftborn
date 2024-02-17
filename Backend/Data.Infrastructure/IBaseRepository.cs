using Models.DTO;

namespace Data.Infrastructure
{
    public interface IBaseRepository<T> where T : class
    {
        T Add(T entity);

        T Update(T entity);

        void Delete(T entity);

        T? GetById(int id);
        ICollection<T> GetAll();
        ICollection<T> GetAll(int pageNumber, int pageSize);
    }
}

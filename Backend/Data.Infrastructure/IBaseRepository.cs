using Data.Repositories.Specification;

namespace Data.Infrastructure
{
    public interface IBaseRepository<T> where T : class
    {
        T Add(T entity);

        T Update(T entity);

        void Delete(T entity);

        T? GetById(int id);
        ICollection<T> GetAll();
        (ICollection<T> Items, int Count) GetAll(int pageNumber, int pageSize);
        IQueryable<T> QuerySpecification(Specification<T> specificaion);

    }
}

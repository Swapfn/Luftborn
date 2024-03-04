using Data.Repositories.Specification;
using Microsoft.EntityFrameworkCore;

namespace Data.Infrastructure
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> dbSet;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }
        public virtual T Add(T entity)
        {
            return dbSet.Add(entity).Entity;
        }
        public virtual T Update(T entity)
        {
            return dbSet.Update(entity).Entity;
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual T? GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual ICollection<T> GetAll()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public virtual (ICollection<T>, int) GetAll(int pageNumber, int pageSize)
        {
            int totalCount = dbSet.Count();
            (ICollection<T> Items, int Count) PagedList = (
                dbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList(),
                totalCount
            );
            return PagedList;
        }
        public IQueryable<T> QuerySpecification(Specification<T> specificaion)
        {
            IQueryable<T> _query = _context.Set<T>();
            if (specificaion.Criteria is not null)
            {
                _query = _query.Where(specificaion.Criteria);
                _ = specificaion.IncludedCriteria.Aggregate(_query, (current, IncludedCriteria) => current.Include(IncludedCriteria));
            }
            return _query;
        }
    }
}

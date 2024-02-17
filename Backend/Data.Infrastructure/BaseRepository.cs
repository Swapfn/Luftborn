using Microsoft.EntityFrameworkCore;
using Models.DTO;

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

        public virtual ICollection<T> GetAll(int pageNumber, int pageSize)
        {
            ICollection<T> PagedList = dbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return PagedList;
        }
    }
}

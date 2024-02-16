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

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.AsNoTracking().ToList();
        }

        //public virtual Response<T> GetAll(int PageNumber, int PageSize, List<string> includes, string SortBy = "", string SortDirection = "")
        //{
        //    //PagedList<T> PagedList = new(pageNumber, pagesize, includes, SortBy, SortDirection);
        //    IQueryable<T> Query = dbSet.AsQueryable<T>();
        //    foreach (string include in includes)
        //    {
        //        Query = Query.Include(include);
        //    }

        //    string SortByParam = "CreatedAt";
        //    string SortDirectionParam = "ASC";

        //    if (!string.IsNullOrEmpty(SortBy))
        //    {
        //        SortByParam = SortBy;
        //    }
        //    if (!string.IsNullOrEmpty(SortDirection))
        //    {
        //        SortDirectionParam = SortDirection;
        //    }

        //    if (SortDirectionParam.ToLower() == "asc")
        //    {
        //        Query = Query.OrderBy(SortByParam);
        //    }
        //    else
        //    {
        //        Query = Query.OrderByDescending(SortByParam);
        //    }

        //    Query = Query.Take(PageSize);

        //    PagedList.Results = Query.Skip((PageNumber - 1) * PageSize).AsNoTracking().ToList();
        //    return PagedList;
        //}
    }
}

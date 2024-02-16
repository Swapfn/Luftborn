namespace Data.Infrastructure
{
    public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
    {
        private readonly ApplicationDbContext _context = context;

        public ApplicationDbContext Context
        {
            get { return _context; }
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public bool SaveChanges()
        {
            try
            {
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}

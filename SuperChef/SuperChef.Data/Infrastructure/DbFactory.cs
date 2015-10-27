
namespace SuperChef.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private AppDbContext _context;

        public AppDbContext GetContext()
        {
            return _context ?? (_context = new AppDbContext("SuperChef"));
        }

        protected override void DisposeCore()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}

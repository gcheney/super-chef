using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SuperChef.Core.Entities;
using SuperChef.Core.Repositories;
using SuperChef.Data.Infrastructure;

namespace SuperChef.Data.Repositories
{
    public class CuisineRepository : Repository<Cuisine, int>, ICuisineRepository
    {
        public CuisineRepository(IDbFactory factory)
            : base(factory)
        {
        }

        public Cuisine FindByName(string cuisineName)
        {
            return Set.FirstOrDefault(c => c.Name == cuisineName);
        }

        public Task<Cuisine> FindByNameAsync(string cuisineName)
        {
            return Set.FirstOrDefaultAsync(c => c.Name == cuisineName);
        }
    }
}


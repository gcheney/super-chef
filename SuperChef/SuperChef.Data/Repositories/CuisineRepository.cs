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
        public CuisineRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public Cuisine FindByName(string cuisineName)
        {
            return Set.FirstOrDefault(c => c.Name == cuisineName);
        }
    }
}


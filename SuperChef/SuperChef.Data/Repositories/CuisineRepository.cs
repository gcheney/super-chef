using System.Linq;
using SuperChef.Core.Entities;
using SuperChef.Core.Repositories;
using SuperChef.Data.Infrastructure;

namespace SuperChef.Data.Repositories
{
    public class CuisineRepository : BaseRepository<Cuisine, int>, ICuisineRepository
    {
        public CuisineRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public Cuisine FindByName(string cuisineName)
        {
            return Set.Where(c => c.Name == cuisineName).FirstOrDefault();
        }
    }
}


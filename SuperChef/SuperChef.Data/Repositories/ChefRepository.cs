using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SuperChef.Core.Entities;
using SuperChef.Core.Repositories;
using SuperChef.Data.Infrastructure;

namespace SuperChef.Data.Repositories
{
    public class ChefRepository : Repository<Chef, int>, IChefRepository
    {
        public ChefRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public Chef FindByName(string chefName)
        {
            return Set.SingleOrDefault(c => c.Name == chefName);
        }

        public Task<Chef> FindByNameAsync(string chefName)
        {
            return Set.SingleOrDefaultAsync(c => c.Name== chefName);
        }

        public Chef FindByUserId(string userId)
        {
            return Set.SingleOrDefault(c => c.UserId == userId);
        }

        public Task<Chef> FindByUserIdAsync(string userId)
        {
            return Set.SingleOrDefaultAsync(c => c.UserId == userId);
        }
    }
}

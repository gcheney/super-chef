using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SuperChef.Core.Entities;
using SuperChef.Core.Repositories;
using SuperChef.Data.Infrastructure;

namespace SuperChef.Data.Repositories
{
    class ChefRepository : Repository<Chef, int>, IChefRepository
    {
        public ChefRepository(IDbFactory factory)
            : base(factory)
        {
        }

        public Chef FindByName(string chefName)
        {
            return Set.FirstOrDefault(r => r.Name == chefName);
        }

        public Task<Chef> FindByNameAsync(string chefName)
        {
            return Set.FirstOrDefaultAsync(r => r.Name == chefName);
        }
    }
}

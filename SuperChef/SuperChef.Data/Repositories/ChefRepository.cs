using System;
using System.Linq;
using SuperChef.Core.Entities;
using SuperChef.Core.Repositories;
using SuperChef.Data.Infrastructure;

namespace SuperChef.Data.Repositories
{
    public class ChefRepository : BaseRepository<Chef, int>, IChefRepository
    {
        public ChefRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public Chef FindByName(string userName)
        {
            return Set.SingleOrDefault(c => c.UserName == userName);
        }

        public Chef FindByUserId(string userId)
        {
            return Set.SingleOrDefault(c => c.UserId == userId);
        }
    }
}

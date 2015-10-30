using SuperChef.Core.Entities;
using SuperChef.Core.Repositories;
using SuperChef.Data.Infrastructure;

namespace SuperChef.Data.Repositories
{
    public class AvatarRepository : Repository<Avatar, int>, IAvatarRepository
    {
        public AvatarRepository(IDbFactory factory) 
            :base(factory)
        {
        }
    }
}

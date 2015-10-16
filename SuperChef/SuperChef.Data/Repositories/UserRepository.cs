using SuperChef.Core.Entities;
using SuperChef.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperChef.Data.Repositories
{
    public class UserRepository : RepositoryBase<ApplicationUser>, IUserRepository
    {
        public UserRepository(IDbContextFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        public ApplicationUser FindByUserName(string username)
        {
            return Set.FirstOrDefault(u => u.UserName == username);
        }

        public Task<ApplicationUser> FindByUserNameAsync(string username)
        {
            return Set.FirstOrDefaultAsync(u => u.UserName == username);
        }

        public ApplicationUser FindByEmail(string email)
        {
            return Set.FirstOrDefault(u => u.Email == email);
        }

        public Task<ApplicationUser> FindByEmailAsync(string email)
        {
            return Set.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}

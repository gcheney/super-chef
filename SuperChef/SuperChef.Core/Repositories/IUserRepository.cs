using SuperChef.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SuperChef.Core.Repositories
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        ApplicationUser FindByUserName(string username);
        Task<ApplicationUser> FindByUserNameAsync(string username);

        ApplicationUser FindByEmail(string email);
        Task<ApplicationUser> FindByEmailAsync(string email);
    }
}

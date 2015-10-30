using SuperChef.Core.Entities;
using System.Threading.Tasks;

namespace SuperChef.Core.Repositories
{
    public interface IChefRepository : IRepository<Chef, int>
    {
        Chef FindByName(string userId);
        Task<Chef> FindByNameAsync(string userId);

        Chef FindByUserId(string userId);
        Task<Chef> FindByUserIdAsync(string userId);
    }
}

using SuperChef.Core.Entities;
using System.Threading.Tasks;

namespace SuperChef.Core.Repositories
{
    public interface IChefRepository : IRepository<Chef, int>
    {
        Chef FindByName(string chefName);
        Task<Chef> FindByNameAsync(string chefName);
    }
}

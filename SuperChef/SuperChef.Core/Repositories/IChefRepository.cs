using SuperChef.Core.Entities;
using System.Threading.Tasks;

namespace SuperChef.Core.Repositories
{
    public interface IChefRepository : IRepository<Chef, int>
    {
        Chef FindByName(string userId);
        Chef FindByUserId(string userId);
    }
}

using SuperChef.Core.Entities;
using System.Threading.Tasks;

namespace SuperChef.Core.Repositories
{
    public interface ICuisineRepository : IRepository<Cuisine, int>
    {
        Cuisine FindByName(string cuisineName);
        Task<Cuisine> FindByNameAsync(string cuisineName);
    }
}

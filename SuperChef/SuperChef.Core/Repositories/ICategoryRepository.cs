using SuperChef.Core.Entities;
using System.Threading.Tasks;

namespace SuperChef.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
        Category FindByName(string categoryName);
    }
}

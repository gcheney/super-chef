using System.Linq;
using SuperChef.Core.Entities;
using SuperChef.Core.Repositories;
using SuperChef.Data.Infrastructure;

namespace SuperChef.Data.Repositories
{
    public class CategoryRepository : Repository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(IDbFactory factory)
            : base(factory)
        {
        }

        public Category FindByName(string categoryName)
        {
            return Set.FirstOrDefault(c => c.Name == categoryName);
        }
    }
}

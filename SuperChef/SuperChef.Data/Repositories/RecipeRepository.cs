using SuperChef.Core.Entities;
using SuperChef.Core.Repositories;
using SuperChef.Data.Infrastructure;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SuperChef.Data.Repositories
{
    public class RecipeRepository : Repository<Recipe, int>, IRecipeRepository
    {
        public RecipeRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}

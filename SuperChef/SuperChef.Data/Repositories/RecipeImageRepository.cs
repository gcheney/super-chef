using SuperChef.Core.Entities;
using SuperChef.Core.Repositories;
using SuperChef.Data.Infrastructure;

namespace SuperChef.Data.Repositories
{
    public class RecipeImageRepository : Repository<RecipeImage, int>, 
        IRecipeImageRepository
    {
        public RecipeImageRepository(IDbFactory factory) 
            : base(factory)
        {
        }
    }
}

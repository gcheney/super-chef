﻿using SuperChef.Core.Entities;
using System.Threading.Tasks;

namespace SuperChef.Core.Repositories
{
    public interface IRecipeRepository : IRepository<Recipe, int>
    {
    }
}

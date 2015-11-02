using SuperChef.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace SuperChef.Core.Services
{
    public interface IChefService
    {
        IEnumerable<Chef> GetAllChefs();
        IEnumerable<Chef> FindChefs(Expression<Func<Chef, bool>> filter);
        Chef GetChef(int id);
        void CreateChef(string userId, string userName);
        void RemoveChef(int id);
    }
}

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
        Chef GetChefByUserName(string userName);
        Chef GetChefByUserId(string userId);
        void CreateChef(string userId, string userName);
        void EditChef(Chef chef);
        void RemoveChef(int id);
    }
}

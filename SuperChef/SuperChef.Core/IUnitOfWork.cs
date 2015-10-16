using SuperChef.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuperChef.Core
{
    public interface IUnitOfWork : IDisposable
    {
        #region Properties
        IUserRepository UserRepository { get; }
        IUserProfileRepository UserProfileRepository { get; }
        #endregion

        #region Methods
        int Commit();
        Task<int> CommitAsync();
        #endregion
    }
}

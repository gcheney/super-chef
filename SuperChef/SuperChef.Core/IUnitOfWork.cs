using System.Threading.Tasks;

namespace SuperChef.Core
{
    public interface IUnitOfWork
    {
        void Commit();
        Task<int> CommitAsync();
    }
}

using System.Threading.Tasks;

namespace SuperChef.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
        Task<int> CommitAsync();
    }
}

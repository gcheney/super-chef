using SuperChef.Core.Entities;
using SuperChef.Core.Repositories;
using SuperChef.Data.Infrastructure;

namespace SuperChef.Data.Repositories
{
    public class CommentRepository : BaseRepository<Comment, int>, ICommentRepository
    {
        public CommentRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

    }
}

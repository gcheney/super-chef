
namespace SuperChef.Data.Infrastructure
{
    public interface IDbFactory
    {
        ApplicationDbContext GetContext();
    }
}

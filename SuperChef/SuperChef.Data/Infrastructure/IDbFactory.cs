
namespace SuperChef.Data.Infrastructure
{
    public interface IDbFactory
    {
        AppDbContext GetContext();
    }
}


namespace SuperChef.Data.Infrastructure
{
    public interface IDbFactory
    {
        SuperChefContext GetContext();
    }
}


namespace SuperChef.Data.Infrastructure
{
    public class ConnectionFactory : IConnectionFactory
    {
        public string GetConnectionString()
        {
            return "SuperChef";
        }
    }
}

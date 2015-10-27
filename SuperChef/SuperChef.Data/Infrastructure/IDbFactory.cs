using System;
using System.Data.Entity;


namespace SuperChef.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        AppDbContext GetContext();
    }
}

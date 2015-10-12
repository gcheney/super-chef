using SuperChef.Core.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SuperChef.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext() 
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
    }
}

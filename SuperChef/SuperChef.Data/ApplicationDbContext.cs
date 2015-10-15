using SuperChef.Core.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SuperChef.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() 
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            //Replaced with Code-First Migrations
            //System.Data.Entity.Database.SetInitializer(new ApplicationDbInitializer());
            System.Data.Entity.Database.SetInitializer<ApplicationDbContext>(null);
        }
    }
}

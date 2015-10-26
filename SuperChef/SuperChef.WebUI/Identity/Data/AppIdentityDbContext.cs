using Microsoft.AspNet.Identity.EntityFramework;
using SuperChef.Web.Identity.Models;

namespace SuperChef.Web.Identity.Data
{
    public class AppIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppIdentityDbContext() 
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
    }
}

using Microsoft.AspNet.Identity.EntityFramework;

namespace SuperChef.Core.Entities
{
    public class AppRole : IdentityRole
    {
        public AppRole() : base() { }

        public AppRole(string name) : base(name) { }
    }
}

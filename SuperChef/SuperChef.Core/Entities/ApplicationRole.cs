using Microsoft.AspNet.Identity.EntityFramework;

namespace SuperChef.Core.Entities
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }

        public ApplicationRole(string name) : base(name) { }
    }
}

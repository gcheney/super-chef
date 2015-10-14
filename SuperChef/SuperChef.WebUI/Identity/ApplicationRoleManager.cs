using Microsoft.AspNet.Identity;
using SuperChef.Core.Entities;

namespace SuperChef.WebUI.Identity
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> roleStore) 
            : base(roleStore)
        {
        }
    }
}
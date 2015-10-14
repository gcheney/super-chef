using Microsoft.AspNet.Identity;
using SuperChef.Core.Entities;

namespace SuperChef.WebUI.Identity
{
    public class AppRoleManager : RoleManager<AppRole>
    {
        public AppRoleManager(IRoleStore<AppRole, string> store) 
            : base(store)
        {
        }
    }
}
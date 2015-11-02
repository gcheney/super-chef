using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using SuperChef.Web.Identity.Models;

namespace SuperChef.Web.Identity.Data
{
    public class IdentityDbInitializer 
        : System.Data.Entity.DropCreateDatabaseAlways<IdentityDb>
    {
        protected override void Seed(IdentityDb context)
        {
            CreateAdminUser(context);
            CreateNonAdminUser(context);
            base.Seed(context);
        }

        private void CreateAdminUser(IdentityDb context)
        {
            var roleResult = new IdentityResult();
            var userResult = new IdentityResult();
            var roleName = "Administrator";
            var userName = "admin";
            var userEmail = "admin@test.com";

            if (!context.Roles.Any(r => r.Name == roleName))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole
                {
                    Name = roleName
                };

                roleResult = roleManager.Create(role);
            }

            if (!context.Users.Any(u => u.Email == userEmail))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser
                {
                    UserName = userName,
                    Email = userEmail
                };

                userResult = userManager.Create(user, "!Password123");

                if (userResult.Succeeded && roleResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, roleName);
                }
            }
        }

        private void CreateNonAdminUser(IdentityDb context)
        {
            if (!context.Users.Any(u => u.Email == "regular@test.com"))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser
                {
                    UserName = "Joe Regular",
                    Email = "regular@test.com"
                };

                userManager.Create(user, "!Password123");
            }
        }
    }
}

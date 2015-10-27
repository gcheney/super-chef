using System.Linq;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using SuperChef.Web.Identity.Models;

namespace SuperChef.Web.Identity.Data
{
    public class AppIdentityDbInitializer 
        : DropCreateDatabaseIfModelChanges<AppIdentityDbContext>
    {
        protected override void Seed(AppIdentityDbContext context)
        {
            var roleResult = new IdentityResult();
            var userResult = new IdentityResult();

            if (!context.Roles.Any(r => r.Name == "AppAdmin"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole
                {
                    Name = "AppAdmin"
                };

                roleResult = roleManager.Create(role);
            }

            if (!context.Users.Any(u => u.Email == "admin@test.com"))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser
                {
                    UserName = "Admin",
                    Email = "admin@test.com"
                };

                userResult = userManager.Create(user, "!Password123");

                if (userResult.Succeeded && roleResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "AppAdmin");
                }
            }

            base.Seed(context);
        }
    }
}

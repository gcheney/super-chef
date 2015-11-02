namespace SuperChef.Web.Identity.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SuperChef.Web.Identity.Models;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IdentityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Identity.Data.Migrations";
        }

        protected override void Seed(IdentityContext context)
        {
            CreateAdminUser(context);
            CreateNonAdminUser(context);
            base.Seed(context);
        }

        private void CreateAdminUser(IdentityContext context)
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

        private void CreateNonAdminUser(IdentityContext context)
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

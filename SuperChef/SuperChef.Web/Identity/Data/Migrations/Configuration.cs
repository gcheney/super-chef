namespace SuperChef.Web.Identity.Data.Migrations
{
    using SuperChef.Web.Identity.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Diagnostics;
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
            CreateUser("Admin", "admin@test.com", context, "Admin");
            CreateUser("KingRamsay", "gordon@test.com", context);
            CreateUser("The_Puckinator", "wolfgang@test.com", context);
            CreateUser("The_Big_O", "jamie@test.com", context);
            CreateUser("RachRay", "rachel@test.com", context);
            base.Seed(context);
        }

        private void CreateUser(string userName, string userEmail, 
            IdentityContext context, string roleName = "")
        {
            if (!context.Users.Any(u => u.Email == userEmail))
            {
                var userResult = new IdentityResult();
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser
                {
                    UserName = userName,
                    Email = userEmail
                };

                //All users have the same password - for testing
                userResult = userManager.Create(user, "!Password123");

                if (!userResult.Succeeded)
                {
                    LogIdentityValidationErrors(userResult.Errors);
                }

                if (!string.IsNullOrWhiteSpace(roleName))
                {
                    if (!context.Roles.Any(r => r.Name == roleName))
                    {
                        var roleResult = new IdentityResult();
                        var roleStore = new RoleStore<IdentityRole>(context);
                        var roleManager = new RoleManager<IdentityRole>(roleStore);
                        var role = new IdentityRole
                        {
                            Name = roleName
                        };

                        roleResult = roleManager.Create(role);

                        if (roleResult.Succeeded)
                        {
                            userManager.AddToRole(user.Id, roleName);
                        }
                        else
                        {
                            LogIdentityValidationErrors(roleResult.Errors);
                        }
                    }
                }
            }
        }

        private void LogIdentityValidationErrors(IEnumerable<string> errors)
        {
            Debug.WriteLine("The following validation errors accured: ");
            foreach (var error in errors)
            {
                Debug.WriteLine(error);
            }
        }
    }
}

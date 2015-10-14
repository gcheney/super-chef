using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using SuperChef.Core.Entities;

namespace SuperChef.Data
{
    public class ApplicationDbInitializer 
        : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "AppAdmin"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole
                {
                    Name = "AppAdmin"
                };

                roleManager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "founder"))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser
                {
                    UserName = "founder@test.com",
                    Email = "founder@test.com"
                };

                var result = userManager.Create(user, "!Password123");
                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "AppAdmin");
                }
            }
        }
    }
}

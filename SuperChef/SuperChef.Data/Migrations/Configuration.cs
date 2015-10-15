namespace SuperChef.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using System.Data.Entity.Migrations;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Linq;
    using Core.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            //Set Migrations to behave like database initializer 
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            if (!context.Roles.Any(r => r.Name == "AppAdmin"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "AppAdmin" };

                roleManager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "founder"))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser
                {
                    UserName = "founder@test.com",
                    Email = "founder@test.com",
                    UserProfile = new UserProfile
                    {
                        DisplayName = "Glendon Cheney",
                        Location = "Austin, TX"
                    }
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

namespace SuperChef.Data.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Core.Entities;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using System.Data.Entity.Validation;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SuperChef.Data.ApplicationDbContext context)
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

            try
            {
                if (!context.Users.Any(u => u.UserName == "founder"))
                {
                    var userStore = new UserStore<ApplicationUser>(context);
                    var userManager = new UserManager<ApplicationUser>(userStore);
                    var user = new ApplicationUser
                    {
                        UserName = "founder@test.com",
                        Email = "founder@test.com"
                    };

                    var password = "!Password123";
                    var result = userManager.Create(user, password);
                    if (result.Succeeded)
                    {
                        userManager.AddToRole(user.Id, "AppAdmin");
                    }

                    var userProfile = new UserProfile
                    {
                        UserProfileId = 1,
                        FirstName = "Glendon",
                        LastName = "Cheney",
                        UserBio = "Fuck You",
                        UserId = user.Id
                    };

                    context.UserProfiles.Add(userProfile);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}

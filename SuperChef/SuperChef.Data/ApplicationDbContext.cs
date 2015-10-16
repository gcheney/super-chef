﻿using SuperChef.Core.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using SuperChef.Data.Configurations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SuperChef.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<UserProfile> UserProfiles { get; set; }

        public ApplicationDbContext() 
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            //Replaced with Code-First Migrations
            //Database.SetInitializer(new ApplicationDbInitializer());
            Database.SetInitializer<ApplicationDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UserProfileConfiguration());

            modelBuilder.Entity<ApplicationUser>()
                .HasRequired(u => u.UserProfile)
                .WithRequiredPrincipal(u => u.User);

            base.OnModelCreating(modelBuilder);
        }
    }
}

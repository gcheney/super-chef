using System;
using SuperChef.Data.Infrastructure;
using SuperChef.Web.Identity.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using SuperChef.Web.Identity.Data.Migrations;

namespace SuperChef.Web.Identity.Data
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext(IConnectionFactory connectionFactory) 
            : base(connectionFactory.GetConnectionString(), throwIfV1Schema: false)
        {
            if (connectionFactory == null)
            {
                throw new ArgumentNullException("connectionFactory");
            }

            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<IdentityContext, Configuration>());
        }
    }
}

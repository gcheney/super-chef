using System;
using SuperChef.Data.Infrastructure;
using SuperChef.Web.Identity.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SuperChef.Web.Identity.Data
{
    public class IdentityDb : IdentityDbContext<ApplicationUser>
    {
        public IdentityDb(IConnectionFactory connectionFactory) 
            : base(connectionFactory.GetConnectionString(), throwIfV1Schema: false)
        {
            if (connectionFactory == null)
            {
                throw new ArgumentNullException("connectionFactory");
            }
        }
    }
}

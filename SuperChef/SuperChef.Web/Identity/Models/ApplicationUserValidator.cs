using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace SuperChef.Web.Identity.Models
{
    public class ApplicationUserValidator : UserValidator<ApplicationUser>
    {
        private readonly ApplicationUserManager _manager;

        public ApplicationUserValidator(ApplicationUserManager manager)
            : base(manager)
        {
            _manager = manager;
        }

        public override async Task<IdentityResult> ValidateAsync(ApplicationUser user)
        {
            IdentityResult result = await base.ValidateAsync(user);

            if (_manager.FindByName(user.UserName) != null)
            {
                var errors = result.Errors.ToList();
                errors.Add("Please choose a new user name.");
                result = new IdentityResult(errors);
            }
            return result;
        }
    }
}
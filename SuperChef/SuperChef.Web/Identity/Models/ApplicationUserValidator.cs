using Microsoft.AspNet.Identity;
using System.Linq;
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
                result = AddIdentityError(result, "Please choose a different user name.");
            }

            if (user.UserName.Contains("@"))
            {
                result = AddIdentityError(result, "User names may not contain an @ symbol.");
            }
            return result;
        }

        private IdentityResult AddIdentityError(IdentityResult result, string errorMessage)
        {
            var errors = result.Errors.ToList();
            errors.Add(errorMessage);
            return new IdentityResult(errors);
        }
    }
}
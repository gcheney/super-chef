using SuperChef.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace SuperChef.WebUI.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Profile
        public ActionResult Index()
        {

            var userId = User.Identity.GetUserId();
            var profile = db.UserProfiles
                .Where(u => u.User.Id == userId)
                .FirstOrDefault();

            return View(profile);
        }
    }
}
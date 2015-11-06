using System.Web.Mvc;

namespace SuperChef.Web.Controllers
{
    public class ChefController : Controller
    {
        // GET: Chef
        public ActionResult Index()
        {
            return View();
        }
    }
}
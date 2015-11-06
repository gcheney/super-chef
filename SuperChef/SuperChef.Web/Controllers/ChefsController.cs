using AutoMapper;
using PagedList;
using System.Net;
using System.Web.Mvc;
using System.Collections.Generic;
using SuperChef.Core.Entities;
using SuperChef.Core.Services;
using SuperChef.Web.ViewModels;

namespace SuperChef.Web.Controllers
{
    [Authorize]
    public class ChefsController : Controller
    {
        private readonly IChefService _chefService;
        private const int PageSize = 3;

        public ChefsController(IChefService chefService)
        {
            _chefService = chefService;
        }

        // GET: Chef
        [AllowAnonymous]
        public ViewResult Index(int? page)
        {
            int pageNumber = (page ?? 1);

            IEnumerable<Chef> chefs = _chefService.GetAllChefs();
            IEnumerable<ChefIndexViewModel> model 
                = Mapper.Map<IEnumerable<Chef>, IEnumerable<ChefIndexViewModel>>(chefs);

            model = model.ToPagedList(pageNumber, PageSize);
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Details(string userName)
        {
            var chefToView = _chefService.GetChefByUserName(userName);

            if (chefToView == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = Mapper.Map<Chef, ChefDetailsViewModel>(chefToView);
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(string userName)
        {
            var chefToEdit = _chefService.GetChefByUserName(userName);

            if (chefToEdit == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = Mapper.Map<Chef, ChefEditViewModel>(chefToEdit);
            return View(model);
        }
    }
}
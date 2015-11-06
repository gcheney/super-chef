using AutoMapper;
using SuperChef.Core.Entities;
using SuperChef.Core.Services;
using SuperChef.Web.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SuperChef.Web.Controllers
{
    public class ChefController : Controller
    {
        private readonly IChefService _chefService;

        public ChefController(IChefService chefService)
        {
            _chefService = chefService;
        }

        // GET: Chef
        public ActionResult Index()
        {
            IEnumerable<Chef> chefs = _chefService.GetAllChefs();

            IEnumerable<ChefIndexViewModel> model 
                = Mapper.Map<IEnumerable<Chef>, IEnumerable<ChefIndexViewModel>>(chefs);

            return View(model);
        }
    }
}
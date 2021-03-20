using InterestExplorerApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InterestExplorerApp.Bll.Abstract;
namespace InterestExplorerApp.Controllers
{
    public class HomeController : Controller
    {
        private IMainCategoryService _mainCategoryService;

        public HomeController(IMainCategoryService mainCategoryService)
        {
            _mainCategoryService = mainCategoryService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetDetail()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult Menu()
        {
            var data = _mainCategoryService.GetAll();
            return PartialView(data);
        }
        public ActionResult Error()
        {
            return View();
        }
      
    }
}
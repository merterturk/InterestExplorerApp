using InterestExplorerApp.Bll.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterestExplorerApp.WebUI.Controllers
{
    public class ErrorController : Controller
    {
        private IMainCategoryService _mainCategoryService;
        public ErrorController(IMainCategoryService mainCategoryService)
        {
            _mainCategoryService = mainCategoryService;
        }
        // GET: Error
        public ActionResult PageNotFound()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult Menu()
        {
            var data = _mainCategoryService.GetAll();
            return PartialView(data);
        }
    }
}
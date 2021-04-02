using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;    
using InterestExplorerApp.Bll.Abstract;
namespace InterestExplorerApp.WebUI.Controllers
{
    public class VideoGameController : Controller
    {
        private IVideoGameService _videoGameService;
        private ICategoryService _categoryService;

        public VideoGameController(IVideoGameService videoGameService,ICategoryService categoryService)
        {
            _videoGameService = videoGameService;
            _categoryService = categoryService;
        }
        public ActionResult VideoGameList(int? categoryId,int? page)
        {
            if (categoryId.HasValue)
            {
                TempData["VideoGameCategory"] = _categoryService.GetCategoryNameByCategoryId(categoryId.Value);
                var result = _videoGameService.GetAllVideoGameDetailsByCategoryId(categoryId.Value);
                return View(result.ToPagedList(page ?? 1, 12));
            }
            return RedirectToAction("PageNotFound", "Error");
        }
        public ActionResult VideoGameDetail(int? Id)
        {
            if (Id.HasValue)
            {
                return View(_videoGameService.GetAllVideoGameDetailsByVideoGameId(Id.Value));
            }
            return RedirectToAction("PageNotFound", "Error");
        }
    }
}
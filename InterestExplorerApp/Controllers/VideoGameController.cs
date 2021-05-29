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
        public ActionResult VideoGameList(int? categoryId,int? page,short? filter)
        {
            if (!categoryId.HasValue)
            {
                return RedirectToAction("PageNotFound", "Error");
            }
            List<SelectListItem> selectlist = new List<SelectListItem>
            {
                       new SelectListItem{Text="A-Z Video Oyun ismine göre sırala",Value="15030"},
                       new SelectListItem{Text="Z-A Video Oyun ismine göre sırala",Value="15040"},
                       new SelectListItem{Text="IMDB puanına göre yüksekten düşüğe sırala",Value="15050"},
                       new SelectListItem{Text="IMDB puanına göre düşükten yükseğe sırala",Value="15060"},
                       new SelectListItem{Text="Yayın yılına göre en son çıkandan ilk çıkana göre sırala",Value="15070"},
                       new SelectListItem{Text="Yayın yılına göre ilk çıkandan en son çıkana göre sırala",Value="15080"}
            };
            ViewBag.Data = selectlist;
            TempData["VideoGameCategory"] = _categoryService.GetCategoryNameByCategoryId(categoryId.Value);
            TempData["HighestImdbForVideoGame"] = _videoGameService.GetHighestImdbScoreByCategoryId(categoryId.Value);
            if (categoryId.HasValue && !filter.HasValue)
            {
                var result = _videoGameService.GetAllVideoGameDetailsByCategoryId(categoryId.Value);
                return View(result.ToPagedList(page ?? 1, 12));
            }
            if (categoryId.HasValue && filter.HasValue)
            {
                var result = _videoGameService.GetVideoGameDetailsByFilter(filter.Value, categoryId.Value);
                return View(result.ToPagedList(page ?? 1, 12));
            }
            return RedirectToAction("PageNotFound", "Error");
        }
        public ActionResult VideoGameDetail(int? Id)
        {
            if (Id.HasValue)
            {
                var result = _videoGameService.GetAllVideoGameDetailsByVideoGameId(Id.Value);
                TempData["GetRandomVideoGame"] = _videoGameService.GetRandomVideoGameDetailsByCategoryId(result.CategoryId);
                return View(result);
            }
            return RedirectToAction("PageNotFound", "Error");
        }
    }
}
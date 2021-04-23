using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InterestExplorerApp.Bll.Abstract;
using PagedList;
using PagedList.Mvc;
namespace InterestExplorerApp.WebUI.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        private IMovieService _movieService;
        private ICategoryService _categoryService;
        public MovieController(IMovieService movieService, ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _movieService = movieService;
        }
        public ActionResult MovieList(int? categoryId, int? page, short? filter)
        {
            if (!categoryId.HasValue)
            {
                return RedirectToAction("PageNotFound", "Error");
            }
            List<SelectListItem> selectlist = new List<SelectListItem>
            {
                       new SelectListItem{Text="A-Z Film ismine göre sırala",Value="15030"},
                       new SelectListItem{Text="Z-A Film ismine göre sırala",Value="15040"},
                       new SelectListItem{Text="IMDB puanına göre yüksekten düşüğe sırala",Value="15050"},
                       new SelectListItem{Text="IMDB puanına göre düşükten yükseğe sırala",Value="15060"},
                       new SelectListItem{Text="Yayın yılına göre en son çıkandan ilk çıkana göre sırala",Value="15070"},
                       new SelectListItem{Text="Yayın yılına göre ilk çıkandan en son çıkana göre sırala",Value="15080"}
            };
            ViewBag.Data = selectlist;
            TempData["MovieCategory"] = _categoryService.GetCategoryNameByCategoryId(categoryId.Value);
            TempData["HighestImdbForMovie"] = _movieService.GetHighestImdbScoreByCategoryId(categoryId.Value);
            if (categoryId.HasValue && !filter.HasValue)
            {
                var result = _movieService.GetAllMovieDetailsByCategoryId(categoryId.Value);
                return View(result.ToPagedList(page ?? 1, 12));
            }
            if (categoryId.HasValue && filter.HasValue)
            {
                var result = _movieService.GetMovieDetailsByFilter(filter.Value, categoryId.Value);
                return View(result.ToPagedList(page ?? 1, 12));
            }
            return RedirectToAction("PageNotFound", "Error");

        }
        public ActionResult MovieDetail(int? Id)
        {
            if (Id.HasValue)
            {
                var result = _movieService.GetMovieDetailsByMovieId(Id.Value);
                TempData["GetRandomMovie"]  = _movieService.GetRandomMovieDetailsByCategoryId(result.CategoryId);
                return View(result);
            }
            return RedirectToAction("PageNotFound", "Error");

        }
    }
}
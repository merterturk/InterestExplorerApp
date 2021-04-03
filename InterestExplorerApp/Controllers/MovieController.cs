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
        public MovieController(IMovieService movieService,ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _movieService = movieService;
        }
        public ActionResult MovieList(int? categoryId,int? page)
        {
            if (categoryId.HasValue)
            {
                TempData["MovieCategory"] = _categoryService.GetCategoryNameByCategoryId(categoryId.Value);
                var result = _movieService.GetAllMovieDetailsByCategoryId(categoryId.Value);
                return View(result.ToPagedList(page ?? 1,12));
            }

            return RedirectToAction("PageNotFound", "Error");
        }
        public ActionResult MovieDetail(int? Id)
        {
            if (Id.HasValue)
            {
                return View(_movieService.GetMovieDetailsByMovieId(Id.Value));
            }
            return RedirectToAction("PageNotFound", "Error");
           
        }
    }
}
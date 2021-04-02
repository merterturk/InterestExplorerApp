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
        private IMovieService _movieService;
        private ICategoryService _categoryService;

        public HomeController(IMainCategoryService mainCategoryService,IMovieService movieService,ICategoryService categoryService)
        {
            _mainCategoryService = mainCategoryService;
            _movieService = movieService;
            _categoryService = categoryService;
        }
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult Menu()
        {
            var menu = _mainCategoryService.GetAll();
            return PartialView(menu);
        }
        [ChildActionOnly]
        public ActionResult Footer()
        {
            var menu = _mainCategoryService.GetAll();
            return PartialView(menu);
        }

        public ActionResult CategoryDetail(int mainCategory,int category)
        {
            switch (mainCategory)
            {
                case 1: return RedirectToAction("MovieList", "Movie",new { categoryId= category });
                case 2: return RedirectToAction("SeriesList", "Series",new {categoryId = category });
                case 3: return RedirectToAction("VideoGameList", "VideoGame", new { categoryId = category });
                case 4: return RedirectToAction("BookList","Book",new {categoryId=category});
            }
            return View();
    
        }
        public ActionResult Search(string search)
        {
            var result = _mainCategoryService.AdvancedSearch(search);
            return View(result);
        }

    }
}
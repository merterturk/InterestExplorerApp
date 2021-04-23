using InterestExplorerApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InterestExplorerApp.Bll.Abstract;
using InterestExplorerApp.Entities.DTOs;

namespace InterestExplorerApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMainCategoryService _mainCategoryService;
        private readonly IMovieService _movieService;
        private readonly ICategoryService _categoryService;
        private readonly IBookService _bookService;
        private readonly ISeriesService _seriesService;
        private readonly IVideoGameService _videoGameService;

        public HomeController(IMainCategoryService mainCategoryService,IMovieService movieService,ICategoryService categoryService,ISeriesService seriesService,IVideoGameService videoGameService,IBookService bookService)
        {
            _mainCategoryService = mainCategoryService;
            _movieService = movieService;
            _categoryService = categoryService;
            _seriesService = seriesService;
            _videoGameService = videoGameService;
            _bookService = bookService;
        }
        public ActionResult Index()
        {
            TempData["LastAddedMovie"] = _movieService.GetLastAddedRecordDetails();
            TempData["LastAddedSeries"] = _seriesService.GetLastAddedRecordDetails();
            TempData["LastAddedVideoGame"] = _videoGameService.GetLastAddedRecordDetails();
            TempData["LastAddedBook"] = _bookService.GetLastAddedRecordDetails();

            TempData["HighestImdbScoreMovie"] = _movieService.GetHighestImdbScore();
            TempData["HighestImdbScoreSeries"] = _seriesService.GetHighestImdbScore();
            TempData["HighestImdbScoreVideoGame"] = _videoGameService.GetHighestImdbScore();

            return View();
        }
        [ChildActionOnly]
        public PartialViewResult Menu()
        {
            var menu = _mainCategoryService.GetAll();
            return PartialView(menu);
        }
        [ChildActionOnly]
        public PartialViewResult Footer()
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
            return RedirectToAction("PageNotFound", "Error");
    
        }
        public ActionResult Search(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return RedirectToAction("PageNotFound", "Error");
            }
            var result = _mainCategoryService.AdvancedSearch(search);
            return View(result);
            
        }

    }
}
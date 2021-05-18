using InterestExplorerApp.Bll.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterestExplorerApp.WebUI.Areas.admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        IMovieService _movieService;
        ISeriesService _seriesService;
        IVideoGameService _videoGameService;
        IBookService _bookService;
        ICategoryService _categoryService;
        IMainCategoryService _mainCategoryService;
        public HomeController(IMovieService movieService,ISeriesService seriesService,IVideoGameService videoGameService,IBookService bookService,ICategoryService categoryService,IMainCategoryService mainCategoryService)
        {
            _movieService = movieService;
            _seriesService = seriesService;
            _videoGameService = videoGameService;
            _bookService = bookService;
            _categoryService = categoryService;
            _mainCategoryService = mainCategoryService;
        }
        public ActionResult Index()
        {
            TempData["MovieCount"] = _movieService.GetTotalMovieCount();
            TempData["LastAddedMovieName"] = _movieService.GetLastAddedMovieName();

            TempData["SeriesCount"] = _seriesService.GetTotalSeriesCount();
            TempData["LastAddedSeriesName"] = _seriesService.GetLastAddedSeriesName();

            TempData["VideoGameCount"] = _videoGameService.GetTotalVideoGameCount();
            TempData["LastAddedVideoGameName"] = _videoGameService.GetLastAddedVideoGameName();

            TempData["BookCount"] = _bookService.GetTotalBookCount();
            TempData["LastAddedBookName"] = _bookService.GetLastAddedBookName();

            TempData["CategoryCount"] = _categoryService.GetTotalCategoryCount();

            TempData["MainCategoryCount"] = _mainCategoryService.GetTotalMainCategoryCount();
            return View();
        }
     
    }
}
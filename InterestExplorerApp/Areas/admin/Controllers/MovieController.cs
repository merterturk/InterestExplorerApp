using InterestExplorerApp.Bll.Abstract;
using InterestExplorerApp.Entities.Concrete;
using InterestExplorerApp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using InterestExplorerApp.WebUI.Helper;

namespace InterestExplorerApp.WebUI.Areas.admin.Controllers
{
    [Authorize]
    public class MovieController : Controller
    {
        IMovieService _movieService;
        ICategoryService _categoryService;

        public MovieController(IMovieService movieService, ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _movieService = movieService;
        }
        [HttpGet]
        public ActionResult AddMovie()
        {
            var allCategory = _categoryService.GetAllByMainCategoryId(1); // 1 = Movie 2= Series 3= VideoGames 4=Book
            List<SelectListItem> category = (from i in allCategory
                                             select new SelectListItem
                                             {
                                                 Value = i.Id.ToString(),
                                                 Text = i.Name
                                             }).ToList();
            ViewBag.Category = category;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMovie(MovieLongDetailsDTO movie)
        {
            var allCategory = _categoryService.GetAllByMainCategoryId(1);
            List<SelectListItem> category = (from i in allCategory
                                             select new SelectListItem
                                             {
                                                 Value = i.Id.ToString(),
                                                 Text = i.Name
                                             }).ToList();
            ViewBag.Category = category;

            if (!ModelState.IsValid)
            {
                return View(movie);
            }
            Movie addMovie = new Movie();
            addMovie.MovieName = movie.MovieName;
            addMovie.MovieDescription = movie.MovieDescription;
            addMovie.CategoryId = movie.CategoryId;
            addMovie.ImageURL = FileHelper.Add(Request.Files[0], "Movie");
            addMovie.IMDBScore = movie.IMDBScore;
            addMovie.TotalTime = movie.TotalTime;
            addMovie.VideoURL = movie.VideoURL;
            addMovie.Year = movie.Year;
            addMovie.IsActive = true;
            addMovie.CreatedDate = DateTime.Now;
            _movieService.Add(addMovie);
            TempData["AddedMessage"] = $"{addMovie.MovieName} Filmi başarıyla eklendi";
            return RedirectToAction("MovieList", "Movie");
        }
        public ActionResult MovieList(int? page, string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var searchingMovie = _movieService.SearchByMovieName(search);
                return View(searchingMovie.ToPagedList(page ?? 1, 10));
            }
            var result = _movieService.GetAll();
            return View(result.ToPagedList(page ?? 1, 10));
        }
        public ActionResult UpdateMovie(int Id)
        {
            var allCategory = _categoryService.GetAllByMainCategoryId(1); // 1 = Movie 2= Series 3= VideoGames 4=Book
            List<SelectListItem> category = (from i in allCategory
                                             select new SelectListItem
                                             {
                                                 Value = i.Id.ToString(),
                                                 Text = i.Name
                                             }).ToList();
            ViewBag.Category = category;
            var movie = _movieService.GetById(Id);
            TempData["ImageURL"] = movie.ImageURL;
            return View(movie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateMovie(Movie movie)
        {
            var allCategory = _categoryService.GetAllByMainCategoryId(1); // 1 = Movie 2= Series 3= VideoGames 4=Book
            List<SelectListItem> category = (from i in allCategory
                                             select new SelectListItem
                                             {
                                                 Value = i.Id.ToString(),
                                                 Text = i.Name
                                             }).ToList();
            ViewBag.Category = category;

            Movie updatedMovie = new Movie();
            updatedMovie.MovieName = movie.MovieName;
            updatedMovie.MovieDescription = movie.MovieDescription;
            updatedMovie.CategoryId = movie.CategoryId;
            updatedMovie.IMDBScore = movie.IMDBScore;
            updatedMovie.TotalTime = movie.TotalTime;
            updatedMovie.VideoURL = movie.VideoURL;
            updatedMovie.Year = movie.Year;
            updatedMovie.Id = movie.Id;
            updatedMovie.CreatedDate = movie.CreatedDate;

            if (Request.Files[0].ContentLength > 0)
            {
                updatedMovie.ImageURL = FileHelper.Add(Request.Files[0], "Movie");
            }
            else
            {
                updatedMovie.ImageURL = TempData["ImageURL"].ToString();
            }
            _movieService.Update(updatedMovie);
            TempData["UpdatedMessage"] = "Kayıt Güncellendi";
            return RedirectToAction("MovieList");
        }
        public ActionResult DeleteMovie(int Id)
        {
            _movieService.Delete(Id);
            TempData["DeletedMessage"] = "Kayıt silindi";
            return RedirectToAction("MovieList");
        }
        public ActionResult MovieDetails(int Id)
        {
            return View(_movieService.GetById(Id));
        }

    }
}
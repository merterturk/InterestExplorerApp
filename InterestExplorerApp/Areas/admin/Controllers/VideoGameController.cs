using InterestExplorerApp.Bll.Abstract;
using InterestExplorerApp.Entities.Concrete;
using InterestExplorerApp.Entities.DTOs;
using InterestExplorerApp.WebUI.Helper;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterestExplorerApp.WebUI.Areas.admin.Controllers
{
    [Authorize]
    public class VideoGameController : Controller
    {
        IVideoGameService _videoGameService;
        ICategoryService _categoryService;

        public VideoGameController(IVideoGameService videoGameService,ICategoryService categoryService)
        {
            _videoGameService = videoGameService;
            _categoryService = categoryService;
        }
        [HttpGet]
        public ActionResult AddVideoGame()
        {
            var allCategory = _categoryService.GetAllByMainCategoryId(3); // 1 = Movie 2= Series 3= VideoGames 4=Book
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
        public ActionResult AddVideoGame(VideoGameLongDetailsDTO videoGame)
        {
            var allCategory = _categoryService.GetAllByMainCategoryId(3);
            List<SelectListItem> category = (from i in allCategory
                                             select new SelectListItem
                                             {
                                                 Value = i.Id.ToString(),
                                                 Text = i.Name
                                             }).ToList();
            ViewBag.Category = category;

            if (!ModelState.IsValid)
            {
                return View(videoGame);
            }
            VideoGame addVideoGame = new VideoGame();
            addVideoGame.VideoGameName = videoGame.VideoGameName;
            addVideoGame.VideoGameDescription = videoGame.VideoGameDescription;
            addVideoGame.CategoryId = videoGame.CategoryId;
            addVideoGame.ImageURL = FileHelper.Add(Request.Files[0], "VideoGame");
            addVideoGame.IMDBScore = videoGame.IMDBScore;
            addVideoGame.VideoURL = videoGame.VideoURL;
            addVideoGame.ReleaseDate = videoGame.ReleaseDate;
            addVideoGame.IsActive = true;
            addVideoGame.CreatedDate = DateTime.Now;
            _videoGameService.Add(addVideoGame);
            TempData["AddedMessage"] = $"{addVideoGame.VideoGameName} Oyunu başarıyla eklendi";
            return RedirectToAction("VideoGameList", "VideoGame");
        }
        public ActionResult VideoGameList(int? page, string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var searchingVideoGame = _videoGameService.SearchByVideoGameName(search);
                return View(searchingVideoGame.ToPagedList(page ?? 1, 10));
            }
            var result = _videoGameService.GetAll();
            return View(result.ToPagedList(page ?? 1, 10));
        }
        [HttpGet]
        public ActionResult UpdateVideoGame(int Id)
        {
            var allCategory = _categoryService.GetAllByMainCategoryId(3); // 1 = Movie 2= Series 3= VideoGames 4=Book
            List<SelectListItem> category = (from i in allCategory
                                             select new SelectListItem
                                             {
                                                 Value = i.Id.ToString(),
                                                 Text = i.Name
                                             }).ToList();
            ViewBag.Category = category;
            var videoGame = _videoGameService.GetById(Id);
            TempData["ImageURL"] = videoGame.ImageURL;
            return View(videoGame);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateVideoGame(VideoGame videoGame)
        {
            var allCategory = _categoryService.GetAllByMainCategoryId(3); // 1 = Movie 2= Series 3= VideoGames 4=Book
            List<SelectListItem> category = (from i in allCategory
                                             select new SelectListItem
                                             {
                                                 Value = i.Id.ToString(),
                                                 Text = i.Name
                                             }).ToList();
            ViewBag.Category = category;

            VideoGame updatedVideoGame = new VideoGame();
            updatedVideoGame.Id = videoGame.Id;
            updatedVideoGame.VideoGameName = videoGame.VideoGameName;
            updatedVideoGame.VideoGameDescription = videoGame.VideoGameDescription;
            updatedVideoGame.CategoryId = videoGame.CategoryId;
            updatedVideoGame.IMDBScore = videoGame.IMDBScore;

            updatedVideoGame.ReleaseDate = videoGame.ReleaseDate;
            updatedVideoGame.VideoURL = videoGame.VideoURL;
            updatedVideoGame.CreatedDate = videoGame.CreatedDate;


            if (Request.Files[0].ContentLength > 0)
            {
                updatedVideoGame.ImageURL = FileHelper.Add(Request.Files[0], "VideoGame");
            }
            else
            {
                updatedVideoGame.ImageURL = TempData["ImageURL"].ToString();
            }
            _videoGameService.Update(updatedVideoGame);
            TempData["UpdatedMessage"] = "Kayıt Güncellendi";
            return RedirectToAction("VideoGameList");
        }
        public ActionResult DeleteVideoGame(int Id)
        {
            _videoGameService.Delete(Id);
            TempData["DeletedMessage"] = "Kayıt silindi";
            return RedirectToAction("VideoGameList");
        }
        public ActionResult VideoGameDetails(int Id)
        {
            return View(_videoGameService.GetById(Id));
        }
    }
}
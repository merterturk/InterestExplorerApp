using InterestExplorerApp.Bll.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using InterestExplorerApp.Entities.DTOs;
using InterestExplorerApp.Entities.Concrete;
using InterestExplorerApp.WebUI.Helper;

namespace InterestExplorerApp.WebUI.Areas.admin.Controllers
{
    [Authorize]
    public class SeriesController : Controller
    {
        ISeriesService _seriesService;
        ICategoryService _categoryService;
        public SeriesController(ISeriesService seriesService,ICategoryService categoryService)
        {
            _seriesService = seriesService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult AddSeries()
        {
            var allCategory = _categoryService.GetAllByMainCategoryId(2); // 1 = Movie 2= Series 3= VideoGames 4=Book
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
        public ActionResult AddSeries(SeriesLongDetailsDTO series)
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
                return View(series);
            }
            Series addSeries = new Series();
            addSeries.SeriesName = series.SeriesName;
            addSeries.SeriesDescription = series.SeriesDescription;
            addSeries.CategoryId = series.CategoryId;
            addSeries.ImageURL = FileHelper.Add(Request.Files[0], "Series");
            addSeries.IMDBScore = series.IMDBScore;
            addSeries.TotalSeason = series.TotalSeason;
            addSeries.TotalEpisode = series.TotalEpisode;
            addSeries.VideoURL = series.VideoURL;
            addSeries.Year = series.Year;
            addSeries.IsActive = true;
            addSeries.CreatedDate = DateTime.Now;
            _seriesService.Add(addSeries);
            TempData["AddedMessage"] = $"{addSeries.SeriesName} Dizisi başarıyla eklendi";
            return RedirectToAction("SeriesList", "Series");
        }
        public ActionResult SeriesList(int? page, string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var searchingSeries = _seriesService.SearchBySeriesName(search);
                return View(searchingSeries.ToPagedList(page ?? 1, 10));
            }
            var result = _seriesService.GetAll();
            return View(result.ToPagedList(page ?? 1, 10));
        }
        [HttpGet]
        public ActionResult UpdateSeries(int Id)
        {
            var allCategory = _categoryService.GetAllByMainCategoryId(2); // 1 = Movie 2= Series 3= VideoGames 4=Book
            List<SelectListItem> category = (from i in allCategory
                                             select new SelectListItem
                                             {
                                                 Value = i.Id.ToString(),
                                                 Text = i.Name
                                             }).ToList();
            ViewBag.Category = category;
            var series = _seriesService.GetById(Id);
            TempData["ImageURL"] = series.ImageURL;
            return View(series);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateSeries(Series series)
        {
            var allCategory = _categoryService.GetAllByMainCategoryId(2); // 1 = Movie 2= Series 3= VideoGames 4=Book
            List<SelectListItem> category = (from i in allCategory
                                             select new SelectListItem
                                             {
                                                 Value = i.Id.ToString(),
                                                 Text = i.Name
                                             }).ToList();
            ViewBag.Category = category;

            Series updatedSeries = new Series();
            updatedSeries.Id = series.Id;
            updatedSeries.SeriesName = series.SeriesName;
            updatedSeries.SeriesDescription = series.SeriesDescription;
            updatedSeries.CategoryId = series.CategoryId;
            updatedSeries.IMDBScore = series.IMDBScore;
            updatedSeries.TotalSeason = series.TotalSeason;
            updatedSeries.TotalEpisode = series.TotalEpisode;
            updatedSeries.Year = series.Year;
            updatedSeries.VideoURL = series.VideoURL;
            updatedSeries.CreatedDate = series.CreatedDate;
           

            if (Request.Files[0].ContentLength > 0)
            {
                updatedSeries.ImageURL = FileHelper.Add(Request.Files[0], "Series");
            }
            else
            {
                updatedSeries.ImageURL = TempData["ImageURL"].ToString();
            }
            _seriesService.Update(updatedSeries);
            TempData["UpdatedMessage"] = "Kayıt Güncellendi";
            return RedirectToAction("SeriesList");
        }
        public ActionResult DeleteSeries(int Id)
        {
            _seriesService.Delete(Id);
            TempData["DeletedMessage"] = "Kayıt silindi";
            return RedirectToAction("SeriesList");
        }
        public ActionResult SeriesDetails(int Id)
        {
            return View(_seriesService.GetById(Id));
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InterestExplorerApp.Bll.Abstract;
using PagedList;

namespace InterestExplorerApp.WebUI.Controllers
{
    public class SeriesController : Controller
    {
        private ISeriesService _seriesService;
        private ICategoryService _categoryService;
        public SeriesController(ISeriesService seriesService,ICategoryService categoryService)
        {
            _seriesService = seriesService;
            _categoryService = categoryService;
        }
  
        public ActionResult SeriesList(int? categoryId,int? page,short? filter)
        {
            if (!categoryId.HasValue)
            {
                return RedirectToAction("PageNotFound", "Error");
            }
            List<SelectListItem> selectlist = new List<SelectListItem>
            {
                       new SelectListItem{Text="A-Z Dizi ismine göre sırala",Value="15030"},
                       new SelectListItem{Text="Z-A Dizi ismine göre sırala",Value="15040"},
                       new SelectListItem{Text="IMDB puanına göre yüksekten düşüğe sırala",Value="15050"},
                       new SelectListItem{Text="IMDB puanına göre düşükten yükseğe sırala",Value="15060"},
                       new SelectListItem{Text="Yayın yılına göre en son çıkandan ilk çıkana göre sırala",Value="15070"},
                       new SelectListItem{Text="Yayın yılına göre ilk çıkandan en son çıkana göre sırala",Value="15080"}
            };
            ViewBag.Data = selectlist;
            TempData["SeriesCategory"] = _categoryService.GetCategoryNameByCategoryId(categoryId.Value);
            TempData["HighestImdbForSeries"] = _seriesService.GetHighestImdbScoreByCategoryId(categoryId.Value);
            if (categoryId.HasValue && !filter.HasValue)
            {
                var result = _seriesService.GetAllSeriesDetailsByCategoryId(categoryId.Value);
                return View(result.ToPagedList(page ?? 1, 12));
            }
            if(categoryId.HasValue && filter.HasValue)
            {
                var result = _seriesService.GetSeriesDetailsByFilter(filter.Value, categoryId.Value);
                return View(result.ToPagedList(page ?? 1, 12));
            }
            return RedirectToAction("PageNotFound", "Error");
            
        }
        public ActionResult SeriesDetail(int? Id)
        {
            if (Id.HasValue)
            {
                var result = _seriesService.GetAllSeriesDetailsBySeriesId(Id.Value);
                TempData["GetRandomSeries"] = _seriesService.GetRandomSeriesDetailsByCategoryId(result.CategoryId);
                return View(result);
            }
            return RedirectToAction("PageNotFound", "Error");

        }

    }
}
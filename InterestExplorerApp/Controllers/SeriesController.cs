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
  
        public ActionResult SeriesList(int? categoryId,int? page)
        {
            if (categoryId.HasValue)
            {
                TempData["SeriesCategory"] = _categoryService.GetCategoryNameByCategoryId(categoryId.Value);
                var result = _seriesService.GetAllSeriesDetailsByCategoryId(categoryId.Value);
                return View(result.ToPagedList(page ?? 1, 12));
            }
            return RedirectToAction("PageNotFound", "Error");
            
        }
        public ActionResult SeriesDetail(int? Id)
        {
            if (Id.HasValue)
            {
                return View(_seriesService.GetAllSeriesDetailsBySeriesId(Id.Value));
            }
            return RedirectToAction("PageNotFound", "Error");

        }

    }
}
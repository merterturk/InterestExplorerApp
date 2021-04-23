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
    public class BookController : Controller
    {
        private IBookService _bookService;
        private ICategoryService _categoryService;

        public BookController(IBookService bookService,ICategoryService categoryService)
        {
            _bookService = bookService;
            _categoryService = categoryService;
        }

        public ActionResult BookList(int? categoryId,int? page,short? filter)
        {
            if (!categoryId.HasValue)
            {
                return RedirectToAction("PageNotFound", "Error");
            }
            List<SelectListItem> selectlist = new List<SelectListItem>
            {
                       new SelectListItem{Text="A-Z Film ismine göre sırala",Value="15030"},
                       new SelectListItem{Text="Z-A Film ismine göre sırala",Value="15040"},
                       new SelectListItem{Text="Yayın yılına göre en son çıkandan ilk çıkana göre sırala",Value="15050"},
                       new SelectListItem{Text="Yayın yılına göre ilk çıkandan en son çıkana göre sırala",Value="15060"}
            };
            ViewBag.Data = selectlist;
            TempData["BookCategory"] = _categoryService.GetCategoryNameByCategoryId(categoryId.Value);
            if (categoryId.HasValue && !filter.HasValue)
            {
                var result = _bookService.GetAllBookDetailsByCategoryId(categoryId.Value);
                return View(result.ToPagedList(page ?? 1,12));
            }
            if(categoryId.HasValue && filter.HasValue)
            {
                var result = _bookService.GetMovieDetailsByFilter(filter.Value, categoryId.Value);
                return View(result.ToPagedList(page ?? 1, 12));
            }

            return RedirectToAction("PageNotFound", "Error");
        }
        public ActionResult BookDetail(int? Id)
        {
            if (Id.HasValue)
            {
                var result = _bookService.GetAllBookDetailsByBookId(Id.Value);
                TempData["GetRandomBook"] = _bookService.GetRandomBookDetailsByCategoryId(result.CategoryId);
                return View(result);
            }
            return RedirectToAction("PageNotFound", "Error");
        }
    }
}
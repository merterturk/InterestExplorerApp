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

        public ActionResult BookList(int? categoryId,int? page)
        {
            if (categoryId.HasValue)
            {
                TempData["BookCategory"] = _categoryService.GetCategoryNameByCategoryId(categoryId.Value);
                var result = _bookService.GetAllBookDetailsByCategoryId(categoryId.Value);
                return View(result.ToPagedList(page ?? 1,12));
            }

            return RedirectToAction("PageNotFound", "Error");
        }
        public ActionResult BookDetail(int? Id)
        {
            if (Id.HasValue)
            {
                return View(_bookService.GetAllBookDetailsByBookId(Id.Value));
            }
            return RedirectToAction("PageNotFound", "Error");
        }
    }
}
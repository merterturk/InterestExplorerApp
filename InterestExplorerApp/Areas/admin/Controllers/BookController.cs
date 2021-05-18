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
    public class BookController : Controller
    {
        IBookService _bookService;
        ICategoryService _categoryService;

        public BookController(IBookService bookService, ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _bookService = bookService;
        }
        [HttpGet]
        public ActionResult AddBook()
        {
            var allCategory = _categoryService.GetAllByMainCategoryId(4); // 1 = Movie 2= Series 3= VideoGames 4=Book
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
        public ActionResult AddBook(BookLongDetailsDTO book)
        {
            var allCategory = _categoryService.GetAllByMainCategoryId(4);
            List<SelectListItem> category = (from i in allCategory
                                             select new SelectListItem
                                             {
                                                 Value = i.Id.ToString(),
                                                 Text = i.Name
                                             }).ToList();
            ViewBag.Category = category;

            if (!ModelState.IsValid)
            {
                return View(book);
            }
            Book addBook = new Book();
            addBook.BookName = book.BookName;
            addBook.BookDescription = book.BookDescription;
            addBook.AuthorName = book.AuthorName;
            addBook.CategoryId = book.CategoryId;
            addBook.ImageURL = FileHelper.Add(Request.Files[0], "Book");
            addBook.PageNumber = book.PageNumber;
            addBook.ReleaseYear = book.ReleaseYear;
            addBook.IsActive = true;
            addBook.CreatedDate = DateTime.Now;
            _bookService.Add(addBook);
            TempData["AddedMessage"] = $"{addBook.BookName} Kitabı başarıyla eklendi";
            return RedirectToAction("BookList", "Book");
        }
        public ActionResult BookList(int? page, string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var searchingMovie = _bookService.SearchByBookName(search);
                return View(searchingMovie.ToPagedList(page ?? 1, 10));
            }
            var result = _bookService.GetAll();
            return View(result.ToPagedList(page ?? 1, 10));
        }
        public ActionResult UpdateBook(int Id)
        {
            var allCategory = _categoryService.GetAllByMainCategoryId(4); // 1 = Movie 2= Series 3= VideoGames 4=Book
            List<SelectListItem> category = (from i in allCategory
                                             select new SelectListItem
                                             {
                                                 Value = i.Id.ToString(),
                                                 Text = i.Name
                                             }).ToList();
            ViewBag.Category = category;
            var movie = _bookService.GetById(Id);
            TempData["ImageURL"] = movie.ImageURL;
            return View(movie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateBook(Book book)
        {
            var allCategory = _categoryService.GetAllByMainCategoryId(4); // 1 = Movie 2= Series 3= VideoGames 4=Book
            List<SelectListItem> category = (from i in allCategory
                                             select new SelectListItem
                                             {
                                                 Value = i.Id.ToString(),
                                                 Text = i.Name
                                             }).ToList();
            ViewBag.Category = category;

            Book updatedBook = new Book();
            updatedBook.BookName = book.BookName;
            updatedBook.BookDescription = book.BookDescription;
            updatedBook.AuthorName = book.AuthorName;
            updatedBook.CategoryId = book.CategoryId;
            updatedBook.ReleaseYear = book.ReleaseYear;
            updatedBook.Id = book.Id;
            updatedBook.PageNumber = book.PageNumber;
            updatedBook.CreatedDate = book.CreatedDate;

            if (Request.Files[0].ContentLength > 0)
            {
                updatedBook.ImageURL = FileHelper.Add(Request.Files[0], "Book");
            }
            else
            {
                updatedBook.ImageURL = TempData["ImageURL"].ToString();
            }
            _bookService.Update(updatedBook);
            TempData["UpdatedMessage"] = "Kayıt Güncellendi";
            return RedirectToAction("BookList");
        }
        public ActionResult DeleteBook(int Id)
        {
            _bookService.Delete(Id);
            TempData["DeletedMessage"] = "Kayıt silindi";
            return RedirectToAction("BookList");
        }
        public ActionResult BookDetails(int Id)
        {
            return View(_bookService.GetById(Id));
        }
    }
}
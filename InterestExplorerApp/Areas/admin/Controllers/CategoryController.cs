using InterestExplorerApp.Bll.Abstract;
using InterestExplorerApp.Entities.Concrete;
using InterestExplorerApp.Entities.DTOs;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterestExplorerApp.WebUI.Areas.admin.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;
        IMainCategoryService _mainCategoryService;
        public CategoryController(ICategoryService categoryService,IMainCategoryService mainCategoryService)
        {
            _mainCategoryService = mainCategoryService;
            _categoryService = categoryService;
        }
       [HttpGet]
        public ActionResult AddCategory()
        {
            var mainCategory = _mainCategoryService.GetAll();
            List<SelectListItem> maincategory = (from i in mainCategory
                                                 select new SelectListItem
                                                 {
                                                     Value = i.Id.ToString(),
                                                     Text = i.MainCategoryName
                                                 }).ToList();
            ViewBag.Category = maincategory;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCategory(AddCategoryDTO category)
        {
            var mainCategory = _mainCategoryService.GetAll();
            List<SelectListItem> maincategory = (from i in mainCategory
                                             select new SelectListItem
                                             {
                                                 Value = i.Id.ToString(),
                                                 Text = i.MainCategoryName
                                             }).ToList();
            ViewBag.Category = maincategory;
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            Category addCategory = new Category();
            addCategory.CategoryName = category.CategoryName;
            addCategory.MainCategoryId = category.MainCategoryId;
            addCategory.CreatedDate = DateTime.Now;
            _categoryService.Add(addCategory);
            TempData["AddedMessage"] = $"{addCategory.CategoryName} Kategorisi başarıyla eklendi";
            return RedirectToAction("CategoryList", "Category");
        }
        public ActionResult CategoryList(int? page, string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var searchingCategory = _categoryService.SearchByCategoryName(search);
                return View(searchingCategory.ToPagedList(page ?? 1, 10));
            }
            var result = _categoryService.GetAll();
            return View(result.ToPagedList(page ?? 1, 10));
        }
        [HttpGet]
        public ActionResult UpdateCategory(int Id)
        {
            var mainCategory = _mainCategoryService.GetAll();
            List<SelectListItem> maincategory = (from i in mainCategory
                                                 select new SelectListItem
                                                 {
                                                     Value = i.Id.ToString(),
                                                     Text = i.MainCategoryName
                                                 }).ToList();
            ViewBag.Category = maincategory;
            var category = _categoryService.GetById(Id);
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateCategory(Category category)
        {
            var mainCategory = _mainCategoryService.GetAll();
            List<SelectListItem> maincategory = (from i in mainCategory
                                                 select new SelectListItem
                                                 {
                                                     Value = i.Id.ToString(),
                                                     Text = i.MainCategoryName
                                                 }).ToList();
            ViewBag.Category = maincategory;
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            Category updatedCategory = new Category();
            updatedCategory.Id = category.Id;
            updatedCategory.CategoryName = category.CategoryName;
            updatedCategory.MainCategoryId = category.MainCategoryId;
            updatedCategory.CreatedDate = category.CreatedDate;
            _categoryService.Update(updatedCategory);
            TempData["UpdatedMessage"] = "Kayıt Güncellendi";
            return RedirectToAction("CategoryList");
        }
        public ActionResult DeleteCategory(int Id)
        {
            _categoryService.Delete(Id);
            TempData["DeletedMessage"] = "Kayıt silindi";
            return RedirectToAction("CategoryList");
        }

    }
}
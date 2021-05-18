using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterestExplorerApp.Dal.Abstract;
using InterestExplorerApp.Entities.Concrete;
using InterestExplorerApp.Entities.DTOs;

namespace InterestExplorerApp.Dal.Concrete.EntityFramework
{
    public class EfCategoryDal : ICategoryDal
    {
        private InterestExplorerContext _context = new InterestExplorerContext();

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var category = _context.Categories.SingleOrDefault(x => x.Id == Id);
            if (category != null)
            {
                category.IsActive = false;
                category.DeletedDate = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public List<Category> GetAll()
        {
            return _context.Categories.Include("MainCategory").Where(x=>x.IsActive==true).ToList();
        }

        public List<CategoryDTO> GetAllByMainCategoryId(int mainCategoryId)
        {
            var result = from c in _context.Categories
                         where c.MainCategoryId == mainCategoryId && c.IsActive==true
                         select new CategoryDTO
                         {
                             Id = c.Id,
                             Name = c.CategoryName
                         };
            return result.ToList();
        }

        public Category GetById(int Id)
        {
            return _context.Categories.SingleOrDefault(x => x.Id == Id);
        }

        public string GetCategoryNameByCategoryId(int categoryId)
        {
            return _context.Categories.SingleOrDefault(x => x.Id == categoryId).CategoryName;
        }

        public int GetTotalCategoryCount()
        {
            return _context.Categories.Where(x=>x.IsActive==true).Count();
        }

        public List<Category> SearchByCategoryName(string search)
        {
            return _context.Categories.Include("MainCategory").Where(x => x.CategoryName.Contains(search) && x.IsActive == true).AsNoTracking().ToList();
        }

        public void Update(Category category)
        {
            _context.Categories.AddOrUpdate(category);
            _context.SaveChanges();

        }

        
    }
}

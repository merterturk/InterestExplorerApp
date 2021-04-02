using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterestExplorerApp.Dal.Abstract;
using InterestExplorerApp.Entities.Concrete;
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

        public void Delete(int categoryId)
        {
            var deletedCategory = _context.Categories.SingleOrDefault(x => x.Id == categoryId);
            _context.Categories.Remove(deletedCategory);
            _context.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return _context.Categories.Include("MainCategory").ToList();
        }



        public Category GetById(int categoryId)
        {
            return _context.Categories.SingleOrDefault(x => x.Id == categoryId);
        }

        public string GetCategoryNameByCategoryId(int categoryId)
        {
            return _context.Categories.SingleOrDefault(x => x.Id == categoryId).CategoryName;
        }

        public void Update(Category category)
        {

        }
    }
}

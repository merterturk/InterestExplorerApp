using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterestExplorerApp.Bll.Abstract;
using InterestExplorerApp.Dal.Abstract;
using InterestExplorerApp.Entities.Concrete;
using InterestExplorerApp.Entities.DTOs;

namespace InterestExplorerApp.Bll.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public void Delete(int Id)
        {
            _categoryDal.Delete(Id);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public List<CategoryDTO> GetAllByMainCategoryId(int mainCategoryId)
        {
            return _categoryDal.GetAllByMainCategoryId(mainCategoryId);
        }

        public Category GetById(int Id)
        {
            return _categoryDal.GetById(Id);
        }

        public string GetCategoryNameByCategoryId(int categoryId)
        {
            return _categoryDal.GetCategoryNameByCategoryId(categoryId);
        }

        public int GetTotalCategoryCount()
        {
            return _categoryDal.GetTotalCategoryCount();
        }

        public List<Category> SearchByCategoryName(string search)
        {
            return _categoryDal.SearchByCategoryName(search);
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }

        
    }
}

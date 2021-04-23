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
        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public List<Category> GetAllByMainCategoryId(int mainCategoryId)
        {
            throw new NotImplementedException();
        }

        public string GetCategoryNameByCategoryId(int categoryId)
        {
            return _categoryDal.GetCategoryNameByCategoryId(categoryId);
        }

        public int GetTotalCategoryCount()
        {
            return _categoryDal.GetTotalCategoryCount();
        }

        List<CategoryDTO> ICategoryService.GetAllByMainCategoryId(int mainCategoryId)
        {
            return _categoryDal.GetAllByMainCategoryId(mainCategoryId);
        }
    }
}

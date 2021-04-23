using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterestExplorerApp.Entities.Concrete;
using InterestExplorerApp.Entities.DTOs;

namespace InterestExplorerApp.Dal.Abstract
{
    public interface ICategoryDal
    {
        List<Category> GetAll();

        List<CategoryDTO> GetAllByMainCategoryId(int mainCategoryId);

        Category GetById(int categoryId);

        void Add(Category category);

        void Update(Category category);

        void Delete(int categoryId);

        string GetCategoryNameByCategoryId(int categoryId);

        int GetTotalCategoryCount();

    }
}

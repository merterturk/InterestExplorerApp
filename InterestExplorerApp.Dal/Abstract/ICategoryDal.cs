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

        List<Category> SearchByCategoryName(string search);

        Category GetById(int Id);

        void Update(Category category);

        void Add(Category category);

        void Delete(int Id);

        string GetCategoryNameByCategoryId(int categoryId);

        int GetTotalCategoryCount();

    }
}

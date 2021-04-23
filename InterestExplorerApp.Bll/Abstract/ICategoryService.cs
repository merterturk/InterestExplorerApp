using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterestExplorerApp.Entities.Concrete;
using InterestExplorerApp.Entities.DTOs;

namespace InterestExplorerApp.Bll.Abstract
{
   public interface ICategoryService
    {
        List<Category> GetAll();

        List<CategoryDTO> GetAllByMainCategoryId(int mainCategoryId);

        string GetCategoryNameByCategoryId(int categoryId);

        int GetTotalCategoryCount();

    }
}

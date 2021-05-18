using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterestExplorerApp.Entities.Concrete;
using InterestExplorerApp.Entities.DTOs;

namespace InterestExplorerApp.Bll.Abstract
{
   public interface IMainCategoryService
    {
        List<MainCategory> GetAll();

        // Movie,Series,VideoGames,Book advanced searcing
        AdvancedSearchDTO AdvancedSearch(string search);


        int GetTotalMainCategoryCount();
    }
}

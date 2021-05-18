using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterestExplorerApp.Entities.Concrete;
using InterestExplorerApp.Entities.DTOs;

namespace InterestExplorerApp.Dal.Abstract
{
    public interface IMainCategoryDal
    {
        List<MainCategory> GetAll();

        AdvancedSearchDTO AdvancedSearch(string search);

        int GetTotalMainCategoryCount();
    }
}

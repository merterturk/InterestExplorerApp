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
   public class MainCategoryManager : IMainCategoryService
    {
        private IMainCategoryDal _mainCategoryDal;

        public MainCategoryManager(IMainCategoryDal mainCategoryDal)
        {
            _mainCategoryDal = mainCategoryDal;
        }

        public AdvancedSearchDTO AdvancedSearch(string search)
        {
            if (search.Length > 5 && !string.IsNullOrEmpty(search))
            {
                return _mainCategoryDal.AdvancedSearch(search);
            }
            return null;
        }

        public List<MainCategory> GetAll()
        {
            return _mainCategoryDal.GetAll();
        }
    }
}

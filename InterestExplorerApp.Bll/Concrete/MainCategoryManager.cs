using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterestExplorerApp.Bll.Abstract;
using InterestExplorerApp.Dal.Abstract;
using InterestExplorerApp.Entities.Concrete;
namespace InterestExplorerApp.Bll.Concrete
{
   public class MainCategoryManager : IMainCategoryService
    {
        private IMainCategoryDal _mainCategoryDal;

        public MainCategoryManager(IMainCategoryDal mainCategoryDal)
        {
            _mainCategoryDal = mainCategoryDal;
        }

        public List<MainCategory> GetAll()
        {
            return _mainCategoryDal.GetAll();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterestExplorerApp.Dal.Abstract;
using InterestExplorerApp.Entities.Concrete;

namespace InterestExplorerApp.Dal.Concrete.EntityFramework
{
    public class EfMainCategoryDal : IMainCategoryDal
    {
        private InterestExplorerContext context = new InterestExplorerContext();

        public List<MainCategory> GetAll()
        {
            return context.MainCategories.Include("Categories").ToList();
        }
    }
}

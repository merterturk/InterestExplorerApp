using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterestExplorerApp.Entities.Concrete;

namespace InterestExplorerApp.Dal.Abstract
{
    public interface ICategoryDal
    {
        List<Category> GetAll();

        Category GetById(int categoryId);

        void Add(Category category);

        void Update(Category category);

        void Delete(int categoryId);

      
    }
}

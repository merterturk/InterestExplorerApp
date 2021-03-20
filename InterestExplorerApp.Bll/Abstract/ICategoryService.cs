using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterestExplorerApp.Entities.Concrete;
namespace InterestExplorerApp.Bll.Abstract
{
   public interface ICategoryService
    {
        List<Category> GetAll();
    }
}

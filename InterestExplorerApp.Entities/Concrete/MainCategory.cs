using InterestExplorerApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Entities.Concrete
{
   public class MainCategory:BaseEntity
    {
        public MainCategory()
        {
            Categories = new List<Category>();
        }

        public string MainCategoryName { get; set; }
        
        public virtual IList<Category> Categories { get; set; }
    }
}

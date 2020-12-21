using InterestExplorerApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Entities.Concrete
{
   public class BaseCategory:BaseEntity
    {
        public BaseCategory()
        {
            Categories = new List<Category>();
        }

        public string Name { get; set; }
        
        public IList<Category> Categories { get; set; }
    }
}

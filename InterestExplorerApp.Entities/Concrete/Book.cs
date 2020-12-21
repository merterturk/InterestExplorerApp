using InterestExplorerApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Entities.Concrete
{
   public class Book:BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string AuthorName { get; set; }

        public short Year { get; set; }

        public short PageNumber { get; set; }

        public string ImageURL { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public bool IsPopular { get; set; }
    }
}

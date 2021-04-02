using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Entities.DTOs
{
   public class BookShortDetailsDTO
    {
        public int Id { get; set; }

        public string BookName { get; set; }

        public string CategoryName { get; set; }

        public string ImageURL { get; set; }

    }
}

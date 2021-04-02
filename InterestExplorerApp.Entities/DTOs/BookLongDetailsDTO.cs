using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Entities.DTOs
{
   public class BookLongDetailsDTO
    {
        public string BookName { get; set; }

        public string CategoryName { get; set; }

        public string BookDescription { get; set; }

        public string AuthorName { get; set; }

        public short ReleaseYear { get; set; }

        public short PageNumber { get; set; }

        public string ImageURL { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Entities.DTOs
{
   public class MovieLongDetailsDTO
    {
        public string MovieName { get; set; }

        public string MovieDescription { get; set; }

        public string CategoryName { get; set; }

        public short TotalTime { get; set; }

        public short Year { get; set; }

        public string IMDBScore { get; set; }

        public string ImageURL { get; set; }

        public string VideoURL { get; set; }
    }
}

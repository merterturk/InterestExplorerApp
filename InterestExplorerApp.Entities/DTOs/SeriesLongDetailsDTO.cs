using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Entities.DTOs
{
   public class SeriesLongDetailsDTO
    {
        public string SeriesName { get; set; }

        public string SeriesDescription { get; set; }

        public string CategoryName { get; set; }

        public string IMDBScore { get; set; }

        public short Year { get; set; }

        public string ImageURL { get; set; }

        public string VideoURL { get; set; }

        public short TotalSeason { get; set; }

        public short TotalEpisode { get; set; }
    }
}

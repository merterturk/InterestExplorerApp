using InterestExplorerApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Entities.Concrete
{
   public class Series:BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public short Year { get; set; }

        public short TotalEpisode { get; set; }

        public short TotalSeason { get; set; }

        public string ImageURL { get; set; }

        public string VideoURL { get; set; }

        public string IMDBScore { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public bool IsPopular { get; set; }
    }
}

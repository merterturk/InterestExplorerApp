using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Entities.DTOs
{
    public class SeriesShortDetailsDTO
    {
        public int Id { get; set; }

        public string SeriesName { get; set; }

        public string CategoryName { get; set; }

        public decimal IMDBScore { get; set; }

        public string ImageURL { get; set; }

    }
}

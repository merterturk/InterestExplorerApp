using InterestExplorerApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Entities.DTOs
{
    public class AdvancedSearchDTO
    {
        public List<MovieShortDetailsDTO> MovieList { get; set; }

        public List<SeriesShortDetailsDTO> SerieList { get; set; }

        public List<VideoGameShortDetailsDTO> VideoGameList { get; set; }

        public List<BookShortDetailsDTO> BookList { get; set; }
    }
}

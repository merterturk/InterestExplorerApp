using InterestExplorerApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Entities.Concrete
{
   public class Category:BaseEntity
    {
        public Category()
        {
            Books = new List<Book>();
            Movies = new List<Movie>();
            Series = new List<Series>();
            VideoGames = new List<VideoGame>();
        }

        public string Name { get; set; }

        public int BaseCategoryId { get; set; }

        public BaseCategory BaseCategory { get; set; }


        public IList<Book> Books { get; set; }

        public IList<Movie> Movies { get; set; }

        public IList<Series> Series { get; set; }

        public IList<VideoGame> VideoGames { get; set; }

    }
}

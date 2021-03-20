using InterestExplorerApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name="Kategori Adı")]
        [Required(ErrorMessage ="Kategori ismini giriniz")]
        [StringLength(150,ErrorMessage ="Kategori İsmi en fazla {0} karakter olmalıdır")]
        public string CategoryName { get; set; }

        public int MainCategoryId { get; set; }

        public virtual MainCategory MainCategory { get; set; }


        public IList<Book> Books { get; set; }

        public IList<Movie> Movies { get; set; }

        public IList<Series> Series { get; set; }

        public IList<VideoGame> VideoGames { get; set; }

    }
}

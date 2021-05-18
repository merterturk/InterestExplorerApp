using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Entities.DTOs
{
   public class BookLongDetailsDTO
    {
        [Required(ErrorMessage = "Roman adını giriniz.")]
        public string BookName { get; set; }

        [Required(ErrorMessage = "Roman açıklamasını giriniz.")]
        public string BookDescription { get; set; }

        public string CategoryName { get; set; }

        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Roman yazarını giriniz.")]
        public string AuthorName { get; set; }
        [Required(ErrorMessage = "Yayın yılını giriniz.")]
        public short ReleaseYear { get; set; }
        [Required(ErrorMessage = "Sayfa sayısını giriniz.")]
        public short PageNumber { get; set; }
        [Required(ErrorMessage = "Romanın bir resmi olmalıdır.")]
        public string ImageURL { get; set; }
    }
}

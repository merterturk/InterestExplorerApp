using InterestExplorerApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Entities.Concrete
{
   public class Book:BaseEntity
    {
        [Display(Name="Kitap İsmi")]
        [Required(ErrorMessage ="Kitap ismini giriniz.")]
        [StringLength(150, ErrorMessage = "Kitap ismi en fazla {0} karakter olmalıdır")]
        public string BookName { get; set; }

        [Display(Name="Kitap Açıklama")]
        [Required(ErrorMessage = "Kitap açıklamasını giriniz.")]
        public string BookDescription { get; set; }

        [Display(Name="Yazar İsmi")]
        [Required(ErrorMessage ="Yazar ismini giriniz.")]
        [StringLength(250, ErrorMessage = "Yazar ismi en fazla {0} karakter olmalıdır.")]
        public string AuthorName { get; set; }

        [Display(Name="Yayın Yılı")]
        [Required(ErrorMessage ="Yayın yılını giriniz.")]
        public short ReleaseYear { get; set; }

        [Display(Name="Sayfa Sayısı")]
        [Required(ErrorMessage ="Sayfa sayısını giriniz.")]
        public short PageNumber { get; set; }

        [Display(Name="Resim Yolu")]
        public string ImageURL { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Display(Name="Popüler mi?")]
        public bool IsPopular { get; set; }
    }
}

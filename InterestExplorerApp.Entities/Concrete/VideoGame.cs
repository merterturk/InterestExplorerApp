using InterestExplorerApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Entities.Concrete
{
    public  class VideoGame: BaseEntity
    {
        [Display(Name = "Oyun Adı")]
        [Required(ErrorMessage = "Oyun adını giriniz.")]
        [StringLength(100, ErrorMessage = "Oyun adı en fazla {0} karakter olmalıdır.")]
        public string VideoGameName { get; set; }

        [Display(Name = "Oyun Açıklama")]
        [Required(ErrorMessage = "Oyun açıklamasını giriniz.")]
        public string VideoGameDescription { get; set; }

        [Display(Name="Yayın Yılı")]
        [Required(ErrorMessage ="Yayın yılını giriniz.")]
        public short ReleaseDate { get; set; }

        [Display(Name = "IMDB puanı")]
        [Required(ErrorMessage = "IMDB puanını giriniz.")]
        public string IMDBScore { get; set; }

        [Display(Name = "Resim Yolu")]
        [Required(ErrorMessage = "Resim yolunu giriniz.")]
        public string ImageURL { get; set; }

        [Display(Name = "Video Yolu")]
        public string VideoURL { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}

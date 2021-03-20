using InterestExplorerApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Entities.Concrete
{
   public class Movie:BaseEntity
    {
        [Display(Name="Film Adı")]
        [Required(ErrorMessage ="Film adını giriniz.")]
        [StringLength(100,ErrorMessage ="Film adı en fazla {0} karakter olmalıdır.")]
        public string MovieName { get; set; }
        [Display(Name = "Film Açıklama")]
        [Required(ErrorMessage ="Film açıklamasını giriniz.")]
        public string MovieDescription { get; set; }
        [Display(Name="Film Yılı")]
        [Required(ErrorMessage ="Film yılını giriniz.")]
        public short Year { get; set; }
        [Display(Name ="Toplam Dakika")]
        [Required(ErrorMessage ="Filmin toplam dakikasını giriniz.")]
        public short TotalTime { get; set; }
        [Display(Name ="Resim Yolu")]
        [Required(ErrorMessage ="Resim yolunu giriniz.")]
        public string ImageURL { get; set; }

        [Display(Name="IMDB puanı")]
        [Required(ErrorMessage ="IMDB puanını giriniz.")]
        public string IMDBScore { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        [Display(Name="Popüler mi?")]
        public bool IsPopular { get; set; }

     
    }
}

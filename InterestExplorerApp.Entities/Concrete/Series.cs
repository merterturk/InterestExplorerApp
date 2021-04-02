using InterestExplorerApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Entities.Concrete
{
   public class Series:BaseEntity
    {
        [Display(Name = "Dizi Adı")]
        [Required(ErrorMessage = "Dizi adını giriniz.")]
        [StringLength(100, ErrorMessage = "Dizi adı en fazla {0} karakter olmalıdır.")]
        public string SeriesName { get; set; }

        [Display(Name = "Dizi Açıklama")]
        [Required(ErrorMessage = "Dizi açıklamasını giriniz.")]
        public string SeriesDescription { get; set; }

        [Display(Name = "Dizi Yılı")]
        [Required(ErrorMessage = "Dizi yılını giriniz.")]
        public short Year { get; set; }

        [Display(Name="Bölüm Sayısı")]
        [Required(ErrorMessage ="Toplam bölüm sayısını giriniz.")]
        public short TotalEpisode { get; set; }

        [Display(Name ="Sezon Sayısı")]
        [Required(ErrorMessage ="Toplam sezon sayısını giriniz.")]
        public short TotalSeason { get; set; }

        [Display(Name = "Resim Yolu")]
        [Required(ErrorMessage = "Resim yolunu giriniz.")]
        public string ImageURL { get; set; }

        [Display(Name ="Video Yolu")]
        public string VideoURL { get; set; }

        [Display(Name = "IMDB puanı")]
        [Required(ErrorMessage = "IMDB puanını giriniz.")]
        public string IMDBScore { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}

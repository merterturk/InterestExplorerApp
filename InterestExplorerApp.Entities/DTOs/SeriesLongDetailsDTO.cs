using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Entities.DTOs
{
   public class SeriesLongDetailsDTO
    {
        [Required(ErrorMessage ="Dizi adını giriniz.")]
        public string SeriesName { get; set; }
        [Required(ErrorMessage = "Dizi açıklamasını giriniz.")]
        public string SeriesDescription { get; set; }

        public string CategoryName { get; set; }

        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Imdb puanını giriniz.")]
        public decimal IMDBScore { get; set; }
        [Required(ErrorMessage = "Yayın yılını giriniz.")]
        public short Year { get; set; }
        [Required(ErrorMessage = "Dizinin bir resmi olmalıdır.")]
        public string ImageURL { get; set; }

        public string VideoURL { get; set; }
        [Required(ErrorMessage = "Sezon sayısını giriniz.")]
        public short TotalSeason { get; set; }
        [Required(ErrorMessage = "Bölüm sayısını giriniz.")]
        public short TotalEpisode { get; set; }
    }
}

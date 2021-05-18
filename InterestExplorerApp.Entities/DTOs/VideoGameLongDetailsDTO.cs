using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Entities.DTOs
{
    public class VideoGameLongDetailsDTO
    {
        [Required(ErrorMessage = "Oyun adını giriniz.")]
        public string VideoGameName { get; set; }
        [Required(ErrorMessage = "Oyun açıklamasını giriniz.")]
        public string VideoGameDescription { get; set; }

        public string CategoryName { get; set; }

        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Yayın Yılını giriniz.")]
        public short ReleaseDate { get; set; }
        [Required(ErrorMessage = "IMDB puanını giriniz.")]
        public decimal IMDBScore { get; set; }
        [Required(ErrorMessage = "Oyunun bir resmi olmalıdır.")]
        public string ImageURL { get; set; }

        public string VideoURL { get; set; }
    }
}

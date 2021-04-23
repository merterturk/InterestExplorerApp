using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Entities.DTOs
{
   public class MovieLongDetailsDTO
    {
        [Required(ErrorMessage = "Film adını giriniz.")]
        [StringLength(100, ErrorMessage = "Film adı en fazla 100 karakter olmalıdır.")]
        public string MovieName { get; set; }
        [Required(ErrorMessage = "Film açıklamasını giriniz.")]
        public string MovieDescription { get; set; }

        public string CategoryName { get; set; }
        // I Put this because i need to get random movie for categoryId
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Toplam zamanı  giriniz.")]
        public short TotalTime { get; set; }
        [Required(ErrorMessage = "Yayın Tarihini giriniz.")]
        public short Year { get; set; }
        [Required(ErrorMessage = "IMDB Skorunu giriniz.")]
        public decimal IMDBScore { get; set; }
        [Required(ErrorMessage = "Filmin bir resmi olmalıdır.")]
        public string ImageURL { get; set; }

        public string VideoURL { get; set; }
    }
}

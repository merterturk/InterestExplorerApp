using InterestExplorerApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Entities.Concrete
{
   public class Movie:BaseEntity
    {
        [Required(ErrorMessage ="Film adını giriniz.")]
        [StringLength(100,ErrorMessage ="Film adı en fazla {0} karakter olmalıdır.")]
        public string MovieName { get; set; }

        [Required(ErrorMessage ="Film açıklamasını giriniz.")]
        public string MovieDescription { get; set; }

        [Required(ErrorMessage ="Film yılını giriniz.")]
        public short Year { get; set; }

        [Required(ErrorMessage ="Filmin toplam dakikasını giriniz.")]
        public short TotalTime { get; set; }

        [Required(ErrorMessage ="IMDB puanını giriniz.")]
        public decimal IMDBScore { get; set; }

        [Required(ErrorMessage = "Resim yolunu giriniz.")]
        public string ImageURL { get; set; }

        public string VideoURL { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}

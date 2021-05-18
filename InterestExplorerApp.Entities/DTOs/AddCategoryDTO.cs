using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Entities.DTOs
{
   public class AddCategoryDTO
    {
        [Required(ErrorMessage ="Kategori Adını Giriniz.")]
        public string CategoryName { get; set; }

        public int MainCategoryId { get; set; }


    }
}

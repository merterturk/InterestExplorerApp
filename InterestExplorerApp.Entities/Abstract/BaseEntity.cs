using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace InterestExplorerApp.Entities.Abstract
{
   public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; } 

        public DateTime? UpdatedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public bool IsActive { get; set; } = true;

    }
}

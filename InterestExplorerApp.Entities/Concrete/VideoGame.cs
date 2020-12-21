using InterestExplorerApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Entities.Concrete
{
    public  class VideoGame: BaseEntity
    {
        public string Name { get; set; }

        public string Desciption { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string ImageURL { get; set; }

        public string VideoURL { get; set; }

        public bool IsPopular { get; set; }


    }
}

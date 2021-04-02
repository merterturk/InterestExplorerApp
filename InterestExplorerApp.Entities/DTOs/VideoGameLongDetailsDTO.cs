using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Entities.DTOs
{
    public class VideoGameLongDetailsDTO
    {
        public string VideoGameName { get; set; }

        public string VideoGameDescription { get; set; }

        public string CategoryName { get; set; }

        public short ReleaseDate { get; set; }

        public string IMDBScore { get; set; }

        public string ImageURL { get; set; }

        public string VideoURL { get; set; }
    }
}

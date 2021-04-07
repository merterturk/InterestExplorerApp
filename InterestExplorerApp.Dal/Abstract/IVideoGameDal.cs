using InterestExplorerApp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Dal.Abstract
{
    public interface IVideoGameDal
    {
        List<VideoGameShortDetailsDTO> GetAllVideoGameDetailsByCategoryId(int categoryId);

        VideoGameLongDetailsDTO GetAllVideoGameDetailsByVideoGameId(int Id);

        List<VideoGameShortDetailsDTO> GetLastAddedRecordDetails();

        List<VideoGameShortDetailsDTO> GetHighestImdbScore();
    }
}

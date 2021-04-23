using InterestExplorerApp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Bll.Abstract
{
    public interface IVideoGameService
    {
        List<VideoGameShortDetailsDTO> GetAllVideoGameDetailsByCategoryId(int categoryId);

        VideoGameLongDetailsDTO GetAllVideoGameDetailsByVideoGameId(int Id);

        List<VideoGameShortDetailsDTO> GetLastAddedRecordDetails();

        List<VideoGameShortDetailsDTO> GetHighestImdbScore();

        List<VideoGameShortDetailsDTO> GetHighestImdbScoreByCategoryId(int categoryId);

        List<VideoGameShortDetailsDTO> GetVideoGameDetailsByFilter(short filter, int categoryId);

        List<VideoGameShortDetailsDTO> GetRandomVideoGameDetailsByCategoryId(int categoryId);

        int GetTotalVideoGameCount();

        string GetLastAddedVideoGameName();
    }
}

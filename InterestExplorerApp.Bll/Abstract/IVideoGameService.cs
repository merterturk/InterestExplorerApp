using InterestExplorerApp.Entities.Concrete;
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
        VideoGame GetById(int Id);

        List<VideoGame> GetAll();

        void Add(VideoGame videoGame);

        void Update(VideoGame videoGame);

        void Delete(int Id);

        List<VideoGameShortDetailsDTO> GetAllVideoGameDetailsByCategoryId(int categoryId);

        VideoGameLongDetailsDTO GetVideoGameDetailsByVideoGameId(int Id);

        List<VideoGameShortDetailsDTO> GetLastAddedRecordDetails();

        List<VideoGameShortDetailsDTO> GetHighestImdbScore();

        List<VideoGameShortDetailsDTO> GetHighestImdbScoreByCategoryId(int categoryId);

        List<VideoGameShortDetailsDTO> GetVideoGameDetailsByFilter(short filter, int categoryId);

        List<VideoGameShortDetailsDTO> GetRandomVideoGameDetailsByCategoryId(int categoryId);

        List<VideoGame> SearchByVideoGameName(string search);

        int GetTotalVideoGameCount();

        string GetLastAddedVideoGameName();
    }
}

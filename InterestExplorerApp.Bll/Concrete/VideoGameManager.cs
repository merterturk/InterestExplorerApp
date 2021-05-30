using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterestExplorerApp.Bll.Abstract;
using InterestExplorerApp.Dal.Abstract;
using InterestExplorerApp.Entities.Concrete;
using InterestExplorerApp.Entities.DTOs;

namespace InterestExplorerApp.Bll.Concrete
{
    public class VideoGameManager : IVideoGameService
    {
        IVideoGameDal _videoGameDal;

        public VideoGameManager(IVideoGameDal videoGameDal)
        {
            _videoGameDal = videoGameDal;
        }

        public void Add(VideoGame videoGame)
        {
            _videoGameDal.Add(videoGame);
        }

        public void Delete(int Id)
        {
            _videoGameDal.Delete(Id);
        }

        public List<VideoGame> GetAll()
        {
            return _videoGameDal.GetAll();
        }

        public List<VideoGameShortDetailsDTO> GetAllVideoGameDetailsByCategoryId(int categoryId)
        {
           return  _videoGameDal.GetAllVideoGameDetailsByCategoryId(categoryId);
        }

        public VideoGameLongDetailsDTO GetVideoGameDetailsByVideoGameId(int Id)
        {
            return _videoGameDal.GetVideoGameDetailsByVideoGameId(Id);
        }

        public VideoGame GetById(int Id)
        {
            return _videoGameDal.GetById(Id);
        }

        public List<VideoGameShortDetailsDTO> GetHighestImdbScore()
        {
            return _videoGameDal.GetHighestImdbScore();
        }

        public List<VideoGameShortDetailsDTO> GetHighestImdbScoreByCategoryId(int categoryId)
        {
            return _videoGameDal.GetHighestImdbScoreByCategoryId(categoryId);
        }

        public List<VideoGameShortDetailsDTO> GetLastAddedRecordDetails()
        {
            return _videoGameDal.GetLastAddedRecordDetails();
        }

        public string GetLastAddedVideoGameName()
        {
            return _videoGameDal.GetLastAddedVideoGameName();
        }

        public List<VideoGameShortDetailsDTO> GetRandomVideoGameDetailsByCategoryId(int categoryId)
        {
            return _videoGameDal.GetRandomVideoGameDetailsByCategoryId(categoryId);
        }

        public int GetTotalVideoGameCount()
        {
            return _videoGameDal.GetTotalVideoGameCount();
        }

        public List<VideoGameShortDetailsDTO> GetVideoGameDetailsByFilter(short filter, int categoryId)
        {
            return _videoGameDal.GetVideoGameDetailsByFilter(filter, categoryId);
        }

        public List<VideoGame> SearchByVideoGameName(string search)
        {
            return _videoGameDal.SearchByVideoGameName(search);
        }

        public void Update(VideoGame videoGame)
        {
            _videoGameDal.Update(videoGame);
        }
    }
}

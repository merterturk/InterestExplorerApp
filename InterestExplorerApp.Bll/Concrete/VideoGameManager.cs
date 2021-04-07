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
        private IVideoGameDal _videoGameDal;

        public VideoGameManager(IVideoGameDal videoGameDal)
        {
            _videoGameDal = videoGameDal;
        }

        public List<VideoGameShortDetailsDTO> GetAllVideoGameDetailsByCategoryId(int categoryId)
        {
           return  _videoGameDal.GetAllVideoGameDetailsByCategoryId(categoryId);
        }

        public VideoGameLongDetailsDTO GetAllVideoGameDetailsByVideoGameId(int Id)
        {
            return _videoGameDal.GetAllVideoGameDetailsByVideoGameId(Id);
        }

        public List<VideoGameShortDetailsDTO> GetHighestImdbScore()
        {
            return _videoGameDal.GetHighestImdbScore();
        }

        public List<VideoGameShortDetailsDTO> GetLastAddedRecordDetails()
        {
            return _videoGameDal.GetLastAddedRecordDetails();
        }
    }
}

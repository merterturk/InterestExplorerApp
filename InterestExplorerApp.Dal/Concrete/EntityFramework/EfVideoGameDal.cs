using InterestExplorerApp.Dal.Abstract;
using InterestExplorerApp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Dal.Concrete.EntityFramework
{
    public class EfVideoGameDal : IVideoGameDal
    {
        private InterestExplorerContext _context = new InterestExplorerContext();

        public List<VideoGameShortDetailsDTO> GetAllVideoGameDetailsByCategoryId(int categoryId)
        {
            var result = from v in _context.VideoGames
                         join c in _context.Categories
                         on v.CategoryId equals c.Id
                         where v.CategoryId == categoryId
                         select new VideoGameShortDetailsDTO
                         {
                             Id = v.Id,
                             VideoGameName = v.VideoGameName,
                             CategoryName = c.CategoryName,
                             ImageURL = v.ImageURL,
                             IMDBScore = v.IMDBScore
                         };
            return result.ToList();
        }

        public VideoGameLongDetailsDTO GetAllVideoGameDetailsByVideoGameId(int Id)
        {
            var result = (from v in _context.VideoGames
                         join c in _context.Categories
                         on v.CategoryId equals c.Id
                         where v.Id == Id
                         select new VideoGameLongDetailsDTO
                         {
                             VideoGameName = v.VideoGameName,
                             VideoGameDescription = v.VideoGameDescription,
                             CategoryName = c.CategoryName,
                             IMDBScore = v.IMDBScore,
                             ReleaseDate = v.ReleaseDate,
                             ImageURL = v.ImageURL,
                             VideoURL = v.VideoURL,
                         }).SingleOrDefault();
            return result;
        }
    }
}

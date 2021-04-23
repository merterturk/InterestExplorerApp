using InterestExplorerApp.Dal.Abstract;
using InterestExplorerApp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            return result.AsNoTracking().ToList();
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
                             CategoryId = v.CategoryId,
                             CategoryName = c.CategoryName,
                             IMDBScore = v.IMDBScore,
                             ReleaseDate = v.ReleaseDate,
                             ImageURL = v.ImageURL,
                             VideoURL = v.VideoURL,
                         }).SingleOrDefault();
            return result;
        }

        public List<VideoGameShortDetailsDTO> GetHighestImdbScore()
        {
            var result = (from v in _context.VideoGames
                          join c in _context.Categories
                          on v.CategoryId equals c.Id
                          orderby v.IMDBScore descending
                          select new VideoGameShortDetailsDTO
                          {
                              Id = v.Id,
                              VideoGameName = v.VideoGameName,
                              CategoryName = c.CategoryName,
                              ImageURL = v.ImageURL,
                              IMDBScore = v.IMDBScore
                          }).Take(12);
            return result.AsNoTracking().ToList();
        }

        public List<VideoGameShortDetailsDTO> GetHighestImdbScoreByCategoryId(int categoryId)
        {
            var result = (from v in _context.VideoGames
                          join c in _context.Categories
                          on v.CategoryId equals c.Id
                          where v.CategoryId == categoryId
                          orderby v.IMDBScore descending
                          select new VideoGameShortDetailsDTO
                          {
                              Id = v.Id,
                              VideoGameName = v.VideoGameName,
                              CategoryName = c.CategoryName,
                              ImageURL = v.ImageURL,
                              IMDBScore = v.IMDBScore
                          }).Take(6);
            return result.AsNoTracking().ToList();
        }

        public List<VideoGameShortDetailsDTO> GetLastAddedRecordDetails()
        {
            var result = (from v in _context.VideoGames
                          join c in _context.Categories
                          on v.CategoryId equals c.Id
                          orderby v.CreatedDate descending
                          select new VideoGameShortDetailsDTO
                          {
                              Id = v.Id,
                              VideoGameName = v.VideoGameName,
                              CategoryName = c.CategoryName,
                              ImageURL = v.ImageURL,
                              IMDBScore = v.IMDBScore
                          }).Take(6);

            return result.ToList();
        }

        public string GetLastAddedVideoGameName()
        {
            return _context.VideoGames
                   .OrderByDescending(x => x.Id)
                   .FirstOrDefault().VideoGameName;
        }

        public List<VideoGameShortDetailsDTO> GetRandomVideoGameDetailsByCategoryId(int categoryId)
        {
            var result = (from v in _context.VideoGames
                          join c in _context.Categories
                          on v.CategoryId equals c.Id
                          where v.CategoryId == categoryId && v.IMDBScore > 7.0M
                          orderby Guid.NewGuid()
                          select new VideoGameShortDetailsDTO
                          {
                              Id = v.Id,
                              VideoGameName = v.VideoGameName,
                              CategoryName = c.CategoryName,
                              ImageURL = v.ImageURL,
                              IMDBScore = v.IMDBScore
                          }).Take(6);
            return result.AsNoTracking().ToList();
        }

        public int GetTotalVideoGameCount()
        {
            return _context.VideoGames.Count();
        }

        public List<VideoGameShortDetailsDTO> GetVideoGameDetailsByFilter(short filter, int categoryId)
        {
            if (filter == 15030)
            {
                var result = from v in _context.VideoGames
                             join c in _context.Categories
                             on v.CategoryId equals c.Id
                             where v.CategoryId == categoryId
                             orderby v.VideoGameName ascending
                             select new VideoGameShortDetailsDTO
                             {
                                 Id = v.Id,
                                 VideoGameName = v.VideoGameName,
                                 CategoryName = c.CategoryName,
                                 ImageURL = v.ImageURL,
                                 IMDBScore = v.IMDBScore
                             };
                return result.AsNoTracking().ToList();
            }
            else if (filter == 15040)
            {
                var result = from v in _context.VideoGames
                             join c in _context.Categories
                             on v.CategoryId equals c.Id
                             where v.CategoryId == categoryId
                             orderby v.VideoGameName descending
                             select new VideoGameShortDetailsDTO
                             {
                                 Id = v.Id,
                                 VideoGameName = v.VideoGameName,
                                 CategoryName = c.CategoryName,
                                 ImageURL = v.ImageURL,
                                 IMDBScore = v.IMDBScore
                             };
                return result.AsNoTracking().ToList();

            }
            else if (filter == 15050)
            {
                var result = from v in _context.VideoGames
                             join c in _context.Categories
                             on v.CategoryId equals c.Id
                             where v.CategoryId == categoryId
                             orderby v.IMDBScore descending
                             select new VideoGameShortDetailsDTO
                             {
                                 Id = v.Id,
                                 VideoGameName = v.VideoGameName,
                                 CategoryName = c.CategoryName,
                                 ImageURL = v.ImageURL,
                                 IMDBScore = v.IMDBScore
                             };
                return result.AsNoTracking().ToList();
            }
            else if (filter == 15060)
            {
                var result = from v in _context.VideoGames
                             join c in _context.Categories
                             on v.CategoryId equals c.Id
                             where v.CategoryId == categoryId
                             orderby v.IMDBScore ascending
                             select new VideoGameShortDetailsDTO
                             {
                                 Id = v.Id,
                                 VideoGameName = v.VideoGameName,
                                 CategoryName = c.CategoryName,
                                 ImageURL = v.ImageURL,
                                 IMDBScore = v.IMDBScore
                             };
                return result.AsNoTracking().ToList();
            }
            else if (filter == 15070)
            {
                var result = from v in _context.VideoGames
                             join c in _context.Categories
                             on v.CategoryId equals c.Id
                             where v.CategoryId == categoryId
                             orderby v.ReleaseDate descending
                             select new VideoGameShortDetailsDTO
                             {
                                 Id = v.Id,
                                 VideoGameName = v.VideoGameName,
                                 CategoryName = c.CategoryName,
                                 ImageURL = v.ImageURL,
                                 IMDBScore = v.IMDBScore
                             };
                return result.AsNoTracking().ToList();
            }
            else if (filter == 15080)
            {
                var result = from v in _context.VideoGames
                             join c in _context.Categories
                             on v.CategoryId equals c.Id
                             where v.CategoryId == categoryId
                             orderby v.ReleaseDate ascending
                             select new VideoGameShortDetailsDTO
                             {
                                 Id = v.Id,
                                 VideoGameName = v.VideoGameName,
                                 CategoryName = c.CategoryName,
                                 ImageURL = v.ImageURL,
                                 IMDBScore = v.IMDBScore
                             };
                return result.AsNoTracking().ToList();
            }
            return null;
        }
    }
}

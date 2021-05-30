using InterestExplorerApp.Dal.Abstract;
using InterestExplorerApp.Entities.Concrete;
using InterestExplorerApp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Dal.Concrete.EntityFramework
{
    public class EfVideoGameDal : IVideoGameDal
    {
        private InterestExplorerContext _context = new InterestExplorerContext();

        public void Add(VideoGame videoGame)
        {
            _context.VideoGames.Add(videoGame);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var videoGame = _context.VideoGames.SingleOrDefault(x => x.Id == Id);
            if (videoGame != null)
            {
                videoGame.IsActive = false;
                videoGame.DeletedDate = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public List<VideoGame> GetAll()
        {
            return _context.VideoGames.Where(x => x.IsActive == true).Include(x => x.Category).AsNoTracking().ToList();
        }

        public List<VideoGameShortDetailsDTO> GetAllVideoGameDetailsByCategoryId(int categoryId)
        {
            var result = from v in _context.VideoGames
                         join c in _context.Categories
                         on v.CategoryId equals c.Id
                         where v.CategoryId == categoryId && v.IsActive==true
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

        public VideoGameLongDetailsDTO GetVideoGameDetailsByVideoGameId(int Id)
        {
            var result = (from v in _context.VideoGames
                         join c in _context.Categories
                         on v.CategoryId equals c.Id
                         where v.Id == Id && v.IsActive == true
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

        public VideoGame GetById(int Id)
        {
            return _context.VideoGames.Include(x => x.Category).SingleOrDefault(x => x.Id == Id);
        }

        public List<VideoGameShortDetailsDTO> GetHighestImdbScore()
        {
            var result = (from v in _context.VideoGames
                          join c in _context.Categories
                          on v.CategoryId equals c.Id
                          where v.IsActive==true
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
                          where v.CategoryId == categoryId && v.IsActive == true
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
                          where v.IsActive == true
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
                   .Where(x=>x.IsActive==true)
                   .FirstOrDefault().VideoGameName;
        }

        public List<VideoGameShortDetailsDTO> GetRandomVideoGameDetailsByCategoryId(int categoryId)
        {
            var result = (from v in _context.VideoGames
                          join c in _context.Categories
                          on v.CategoryId equals c.Id
                          where v.CategoryId == categoryId && v.IMDBScore > 6.0M && v.IsActive == true
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
            return _context.VideoGames.Where(x=>x.IsActive==true).Count();
        }

        public List<VideoGameShortDetailsDTO> GetVideoGameDetailsByFilter(short filter, int categoryId)
        {
            if (filter == 15030)
            {
                var result = from v in _context.VideoGames
                             join c in _context.Categories
                             on v.CategoryId equals c.Id
                             where v.CategoryId == categoryId && v.IsActive == true
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
                             where v.CategoryId == categoryId && v.IsActive == true
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
                             where v.CategoryId == categoryId && v.IsActive == true
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
                             where v.CategoryId == categoryId && v.IsActive == true
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
                             where v.CategoryId == categoryId && v.IsActive == true
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
                             where v.CategoryId == categoryId && v.IsActive == true
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

        public List<VideoGame> SearchByVideoGameName(string search)
        {
            return _context.VideoGames.Include(v => v.Category).Where(v => v.VideoGameName.Contains(search) && v.IsActive == true).AsNoTracking().ToList();
        }

        public void Update(VideoGame videoGame)
        {
            _context.VideoGames.AddOrUpdate(videoGame);
            _context.SaveChanges();
        }
    }
}

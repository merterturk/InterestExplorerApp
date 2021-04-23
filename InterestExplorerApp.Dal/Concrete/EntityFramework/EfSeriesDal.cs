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
    public class EfSeriesDal : ISeriesDal
    {
        private InterestExplorerContext _context = new InterestExplorerContext();

        public List<SeriesShortDetailsDTO> GetAllSeriesDetailsByCategoryId(int categoryId)
        {
            var result = from s in _context.Series
                         join c in _context.Categories
                         on s.CategoryId equals c.Id
                         where s.CategoryId == categoryId
                         select new SeriesShortDetailsDTO
                         {
                             Id = s.Id,
                             SeriesName = s.SeriesName,
                             CategoryName = c.CategoryName,
                             ImageURL = s.ImageURL,
                             IMDBScore = s.IMDBScore
                         };
            return result.AsNoTracking().ToList();
        }

        public SeriesLongDetailsDTO GetAllSeriesDetailsBySeriesId(int Id)
        {
            var result = (from s in _context.Series
                          join c in _context.Categories
                          on s.CategoryId equals c.Id
                          where s.Id == Id
                          select new SeriesLongDetailsDTO
                          {
                              SeriesName = s.SeriesName,
                              SeriesDescription = s.SeriesDescription,
                              CategoryId = s.CategoryId,
                              CategoryName = c.CategoryName,
                              ImageURL = s.ImageURL,
                              VideoURL = s.VideoURL,
                              IMDBScore = s.IMDBScore,
                              Year = s.Year,
                              TotalSeason = s.TotalSeason,
                              TotalEpisode = s.TotalEpisode
                          }).SingleOrDefault();
            return result;
        }

        public List<SeriesShortDetailsDTO> GetHighestImdbScore()
        {
            var result = (from s in _context.Series
                          join c in _context.Categories
                          on s.CategoryId equals c.Id
                          orderby s.IMDBScore descending
                          select new SeriesShortDetailsDTO
                          {
                              Id = s.Id,
                              SeriesName = s.SeriesName,
                              CategoryName = c.CategoryName,
                              ImageURL = s.ImageURL,
                              IMDBScore = s.IMDBScore
                          }).Take(12);
            return result.AsNoTracking().ToList();
        }

        public List<SeriesShortDetailsDTO> GetHighestImdbScoreByCategoryId(int categoryId)
        {
            var result = (from s in _context.Series
                          join c in _context.Categories
                          on s.CategoryId equals c.Id
                          where s.CategoryId == categoryId
                          orderby s.IMDBScore descending
                          select new SeriesShortDetailsDTO
                          {
                              Id = s.Id,
                              SeriesName = s.SeriesName,
                              CategoryName = c.CategoryName,
                              ImageURL = s.ImageURL,
                              IMDBScore = s.IMDBScore
                          }).Take(6);
            return result.AsNoTracking().ToList();
        }

        public List<SeriesShortDetailsDTO> GetLastAddedRecordDetails()
        {
            var result = (from s in _context.Series
                          join c in _context.Categories
                          on s.CategoryId equals c.Id
                          orderby s.CreatedDate descending
                          select new SeriesShortDetailsDTO
                          {
                              Id = s.Id,
                              SeriesName = s.SeriesName,
                              CategoryName = c.CategoryName,
                              ImageURL = s.ImageURL,
                              IMDBScore = s.IMDBScore
                          }).Take(6);

            return result.ToList();
        }

        public string GetLastAddedSeriesName()
        {
            return _context.Series
                   .OrderByDescending(x => x.Id)
                   .FirstOrDefault().SeriesName;
        }

        public List<SeriesShortDetailsDTO> GetRandomSeriesDetailsByCategoryId(int categoryId)
        {
            var result = (from s in _context.Series
                          join c in _context.Categories
                          on s.CategoryId equals c.Id
                          where s.CategoryId == categoryId && s.IMDBScore > 7.0M
                          orderby Guid.NewGuid()
                          select new SeriesShortDetailsDTO
                          {
                              Id = s.Id,
                              SeriesName = s.SeriesName,
                              CategoryName = c.CategoryName,
                              ImageURL = s.ImageURL,
                              IMDBScore = s.IMDBScore
                          }).Take(6);
            return result.AsNoTracking().ToList();
        }

        public List<SeriesShortDetailsDTO> GetSeriesDetailsByFilter(short filter, int categoryId)
        {
            if (filter == 15030)
            {
                var result = from s in _context.Series
                             join c in _context.Categories
                             on s.CategoryId equals c.Id
                             where s.CategoryId == categoryId
                             orderby s.SeriesName ascending
                             select new SeriesShortDetailsDTO
                             {
                                 Id = s.Id,
                                 SeriesName = s.SeriesName,
                                 CategoryName = c.CategoryName,
                                 ImageURL = s.ImageURL,
                                 IMDBScore = s.IMDBScore
                             };
                return result.AsNoTracking().ToList();
            }
            else if (filter == 15040)
            {
                var result = from s in _context.Series
                             join c in _context.Categories
                             on s.CategoryId equals c.Id
                             where s.CategoryId == categoryId
                             orderby s.SeriesName descending
                             select new SeriesShortDetailsDTO
                             {
                                 Id = s.Id,
                                 SeriesName = s.SeriesName,
                                 CategoryName = c.CategoryName,
                                 ImageURL = s.ImageURL,
                                 IMDBScore = s.IMDBScore
                             };
                return result.AsNoTracking().ToList();

            }
            else if (filter == 15050)
            {
                var result = from s in _context.Series
                             join c in _context.Categories
                             on s.CategoryId equals c.Id
                             where s.CategoryId == categoryId
                             orderby s.IMDBScore descending
                             select new SeriesShortDetailsDTO
                             {
                                 Id = s.Id,
                                 SeriesName = s.SeriesName,
                                 CategoryName = c.CategoryName,
                                 ImageURL = s.ImageURL,
                                 IMDBScore = s.IMDBScore
                             };
                return result.AsNoTracking().ToList();
            }
            else if (filter == 15060)
            {
                var result = from s in _context.Series
                             join c in _context.Categories
                             on s.CategoryId equals c.Id
                             where s.CategoryId == categoryId
                             orderby s.IMDBScore ascending
                             select new SeriesShortDetailsDTO
                             {
                                 Id = s.Id,
                                 SeriesName = s.SeriesName,
                                 CategoryName = c.CategoryName,
                                 ImageURL = s.ImageURL,
                                 IMDBScore = s.IMDBScore
                             };
                return result.AsNoTracking().ToList();
            }
            else if (filter == 15070)
            {
                var result = from s in _context.Series
                             join c in _context.Categories
                             on s.CategoryId equals c.Id
                             where s.CategoryId == categoryId
                             orderby s.Year descending
                             select new SeriesShortDetailsDTO
                             {
                                 Id = s.Id,
                                 SeriesName = s.SeriesName,
                                 CategoryName = c.CategoryName,
                                 ImageURL = s.ImageURL,
                                 IMDBScore = s.IMDBScore
                             };
                return result.AsNoTracking().ToList();
            }
            else if (filter == 15080)
            {
                var result = from s in _context.Series
                             join c in _context.Categories
                             on s.CategoryId equals c.Id
                             where s.CategoryId == categoryId
                             orderby s.Year ascending
                             select new SeriesShortDetailsDTO
                             {
                                 Id = s.Id,
                                 SeriesName = s.SeriesName,
                                 CategoryName = c.CategoryName,
                                 ImageURL = s.ImageURL,
                                 IMDBScore = s.IMDBScore
                             };
                return result.AsNoTracking().ToList();
            }
            return null;
        }

        public int GetTotalSeriesCount()
        {
            return _context.Series.Count();
        }
    }
}

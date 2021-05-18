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
    public class EfSeriesDal : ISeriesDal
    {
        private InterestExplorerContext _context = new InterestExplorerContext();

        public void Add(Series series)
        {
            _context.Series.Add(series);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var series = _context.Series.SingleOrDefault(x => x.Id == Id);
            if (series != null)
            {
                series.IsActive = false;
                series.DeletedDate = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public List<Series> GetAll()
        {
            return _context.Series.Where(x => x.IsActive == true).Include(x => x.Category).AsNoTracking().ToList();
        }

        public List<SeriesShortDetailsDTO> GetAllSeriesDetailsByCategoryId(int categoryId)
        {
            var result = from s in _context.Series
                         join c in _context.Categories
                         on s.CategoryId equals c.Id
                         where s.CategoryId == categoryId && s.IsActive==true
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
                          where s.Id == Id && s.IsActive==true
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

        public Series GetById(int Id)
        {
            return _context.Series.Include(x => x.Category).SingleOrDefault(x => x.Id == Id);
        }

        public List<SeriesShortDetailsDTO> GetHighestImdbScore()
        {
            var result = (from s in _context.Series
                          join c in _context.Categories
                          on s.CategoryId equals c.Id
                          where s.IsActive == true
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
                          where s.CategoryId == categoryId && s.IsActive == true
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
                          where s.IsActive == true
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
                   .Where(x=>x.IsActive==true)
                   .FirstOrDefault().SeriesName;
        }

        public List<SeriesShortDetailsDTO> GetRandomSeriesDetailsByCategoryId(int categoryId)
        {
            var result = (from s in _context.Series
                          join c in _context.Categories
                          on s.CategoryId equals c.Id
                          where s.CategoryId == categoryId && s.IMDBScore > 7.0M && s.IsActive==true
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
                             where s.CategoryId == categoryId && s.IsActive == true
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
                             where s.CategoryId == categoryId && s.IsActive == true
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
                             where s.CategoryId == categoryId && s.IsActive == true
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
                             where s.CategoryId == categoryId && s.IsActive == true
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
                             where s.CategoryId == categoryId && s.IsActive == true
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
                             where s.CategoryId == categoryId && s.IsActive == true
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
            return _context.Series.Where(s=>s.IsActive==true).Count();
        }

        public List<Series> SearchBySeriesName(string search)
        {
            return _context.Series.Include(s => s.Category).Where(s=>s.SeriesName.Contains(search) && s.IsActive == true).AsNoTracking().ToList();
        }

        public void Update(Series series)
        {
            _context.Series.AddOrUpdate(series);
            _context.SaveChanges();
        }
    }
}

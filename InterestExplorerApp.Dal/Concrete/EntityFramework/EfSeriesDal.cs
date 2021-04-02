using InterestExplorerApp.Dal.Abstract;
using InterestExplorerApp.Entities.DTOs;
using System;
using System.Collections.Generic;
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
            return result.ToList();
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
    }
}

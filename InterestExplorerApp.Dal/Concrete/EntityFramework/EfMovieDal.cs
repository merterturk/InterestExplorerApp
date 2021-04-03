using InterestExplorerApp.Dal.Abstract;
using InterestExplorerApp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Dal.Concrete.EntityFramework
{
    public class EfMovieDal : IMovieDal
    {
        private  InterestExplorerContext _context = new InterestExplorerContext();

        public List<MovieShortDetailsDTO> GetAllMovieDetailsByCategoryId(int categoryId)
        {
            var result = from m in _context.Movies
                         join c in _context.Categories
                         on m.CategoryId equals c.Id
                         where m.CategoryId==categoryId
                         select new MovieShortDetailsDTO
                         {
                             Id = m.Id,
                             MovieName = m.MovieName,
                             CategoryName = c.CategoryName,
                             ImageURL = m.ImageURL,
                             IMDBScore = m.IMDBScore
                         };
            return result.ToList();
            
        }

        public MovieLongDetailsDTO GetMovieDetailsByMovieId(int Id)
        {
            var result = (from m in _context.Movies
                          join c in _context.Categories
                          on m.CategoryId equals c.Id
                          where m.Id == Id
                          select new MovieLongDetailsDTO
                          {
                              MovieName = m.MovieName,
                              MovieDescription = m.MovieDescription,
                              CategoryName = c.CategoryName,
                              ImageURL = m.ImageURL,
                              VideoURL = m.VideoURL,
                              IMDBScore = m.IMDBScore,
                              Year = m.Year,
                              TotalTime = m.TotalTime
                          }).SingleOrDefault();
            return result;
        }

        public List<MovieShortDetailsDTO> GetLastAddedRecordDetails()
        {
            var result = (from m in _context.Movies
                          join c in _context.Categories
                          on m.CategoryId equals c.Id
                          orderby m.CreatedDate descending
                          select new MovieShortDetailsDTO
                          {
                              Id = m.Id,
                              MovieName = m.MovieName,
                              CategoryName = c.CategoryName,
                              ImageURL = m.ImageURL,
                              IMDBScore = m.IMDBScore
                          }).Take(6);
            return result.ToList();
        }
    }
}

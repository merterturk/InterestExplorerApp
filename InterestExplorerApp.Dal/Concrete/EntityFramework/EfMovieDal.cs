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
    public class EfMovieDal : IMovieDal
    {
        private InterestExplorerContext _context = new InterestExplorerContext();

        public List<MovieShortDetailsDTO> GetAllMovieDetailsByCategoryId(int categoryId)
        {
            var result = from m in _context.Movies
                         join c in _context.Categories
                         on m.CategoryId equals c.Id
                         where m.CategoryId == categoryId && m.IsActive==true
                         select new MovieShortDetailsDTO
                         {
                             Id = m.Id,
                             MovieName = m.MovieName,
                             CategoryName = c.CategoryName,
                             ImageURL = m.ImageURL,
                             IMDBScore = m.IMDBScore
                         };
            return result.AsNoTracking().ToList();

        }

        public MovieLongDetailsDTO GetMovieDetailsByMovieId(int Id)
        {
            var result = (from m in _context.Movies
                          join c in _context.Categories
                          on m.CategoryId equals c.Id
                          where m.Id == Id &&  m.IsActive == true
                          select new MovieLongDetailsDTO
                          {
                              MovieName = m.MovieName,
                              MovieDescription = m.MovieDescription,
                              CategoryName = c.CategoryName,
                              CategoryId = m.CategoryId,
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
                          where m.IsActive == true
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

        public List<MovieShortDetailsDTO> GetHighestImdbScore()
        {
            var result = (from m in _context.Movies
                          join c in _context.Categories
                          on m.CategoryId equals c.Id
                          where  m.IsActive == true
                          orderby m.IMDBScore descending
                          select new MovieShortDetailsDTO
                          {
                              Id = m.Id,
                              MovieName = m.MovieName,
                              CategoryName = c.CategoryName,
                              ImageURL = m.ImageURL,
                              IMDBScore = m.IMDBScore
                          }).Take(12);
            return result.AsNoTracking().ToList();
        }

        public List<MovieShortDetailsDTO> GetHighestImdbScoreByCategoryId(int categoryId)
        {
            var result = (from m in _context.Movies
                          join c in _context.Categories
                          on m.CategoryId equals c.Id
                          where m.CategoryId == categoryId && m.IsActive == true
                          orderby m.IMDBScore descending
                          select new MovieShortDetailsDTO
                          {
                              Id = m.Id,
                              MovieName = m.MovieName,
                              CategoryName = c.CategoryName,
                              ImageURL = m.ImageURL,
                              IMDBScore = m.IMDBScore
                          }).Take(6);
            return result.AsNoTracking().ToList();
        }

        public List<MovieShortDetailsDTO> GetMovieDetailsByFilter(short filter,int categoryId)
        {
            if(filter == 15030)
            {
                var result = from m in _context.Movies
                             join c in _context.Categories
                             on m.CategoryId equals c.Id
                             where m.CategoryId == categoryId && m.IsActive == true
                             orderby m.MovieName ascending
                             select new MovieShortDetailsDTO
                             {
                                 Id = m.Id,
                                 MovieName = m.MovieName,
                                 CategoryName = c.CategoryName,
                                 ImageURL = m.ImageURL,
                                 IMDBScore = m.IMDBScore
                             };
                return result.AsNoTracking().ToList();
            }
            else if (filter == 15040)
            {
                var result = from m in _context.Movies
                             join c in _context.Categories
                             on m.CategoryId equals c.Id
                             where m.CategoryId == categoryId && m.IsActive == true
                             orderby m.MovieName descending
                             select new MovieShortDetailsDTO
                             {
                                 Id = m.Id,
                                 MovieName = m.MovieName,
                                 CategoryName = c.CategoryName,
                                 ImageURL = m.ImageURL,
                                 IMDBScore = m.IMDBScore
                             };
                return result.AsNoTracking().ToList();

            }
            else if (filter == 15050)
            {
                var result = from m in _context.Movies
                             join c in _context.Categories
                             on m.CategoryId equals c.Id
                             where m.CategoryId == categoryId && m.IsActive == true
                             orderby m.IMDBScore descending
                             select new MovieShortDetailsDTO
                             {
                                 Id = m.Id,
                                 MovieName = m.MovieName,
                                 CategoryName = c.CategoryName,
                                 ImageURL = m.ImageURL,
                                 IMDBScore = m.IMDBScore
                             };
                return result.AsNoTracking().ToList();
            }
            else if (filter == 15060)
            {
                var result = from m in _context.Movies
                             join c in _context.Categories
                             on m.CategoryId equals c.Id
                             where m.CategoryId == categoryId && m.IsActive == true
                             orderby m.IMDBScore ascending
                             select new MovieShortDetailsDTO
                             {
                                 Id = m.Id,
                                 MovieName = m.MovieName,
                                 CategoryName = c.CategoryName,
                                 ImageURL = m.ImageURL,
                                 IMDBScore = m.IMDBScore
                             };
                return result.AsNoTracking().ToList();
            }
            else if(filter == 15070)
            {
                var result = from m in _context.Movies
                             join c in _context.Categories
                             on m.CategoryId equals c.Id
                             where m.CategoryId == categoryId && m.IsActive == true
                             orderby m.Year descending
                             select new MovieShortDetailsDTO
                             {
                                 Id = m.Id,
                                 MovieName = m.MovieName,
                                 CategoryName = c.CategoryName,
                                 ImageURL = m.ImageURL,
                                 IMDBScore = m.IMDBScore
                             };
                return result.AsNoTracking().ToList();
            }
            else if (filter == 15080)
            {
                var result = from m in _context.Movies
                             join c in _context.Categories
                             on m.CategoryId equals c.Id
                             where m.CategoryId == categoryId && m.IsActive==true
                             orderby m.Year ascending
                             select new MovieShortDetailsDTO
                             {
                                 Id = m.Id,
                                 MovieName = m.MovieName,
                                 CategoryName = c.CategoryName,
                                 ImageURL = m.ImageURL,
                                 IMDBScore = m.IMDBScore
                             };
                return result.AsNoTracking().ToList();
            }
            return null;
        }

        public List<MovieShortDetailsDTO> GetRandomMovieDetailsByCategoryId(int categoryId)
        {
            var result = (from m in _context.Movies
                         join c in _context.Categories
                         on m.CategoryId equals c.Id
                         where m.CategoryId == categoryId && m.IMDBScore>6.0M && m.IsActive==true
                         orderby Guid.NewGuid()
                         select new MovieShortDetailsDTO
                         {
                             Id = m.Id,
                             MovieName = m.MovieName,
                             CategoryName = c.CategoryName,
                             ImageURL = m.ImageURL,
                             IMDBScore = m.IMDBScore
                         }).Take(6);
            return result.AsNoTracking().ToList();
        }
        public List<Movie> GetAll()
        {
            return _context.Movies.Where(x=>x.IsActive==true).Include(x=>x.Category).AsNoTracking().ToList();
        }

        public Movie GetById(int Id)
        {
            return _context.Movies.Include(x=>x.Category).SingleOrDefault(x => x.Id == Id);
        }

        public void Update(Movie movie)
        {
            _context.Movies.AddOrUpdate(movie);
            _context.SaveChanges();
        }

        public List<Movie> SearchByMovieName(string search)
        {
            return _context.Movies.Include(x=>x.Category).Where(x => x.MovieName.Contains(search) && x.IsActive==true).AsNoTracking().ToList();
        }

        public void Add(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public int GetTotalMovieCount()
        {
            return _context.Movies.Where(x=>x.IsActive==true).Count();
        }

        public string GetLastAddedMovieName()
        {
           return _context.Movies
                         .OrderByDescending(x => x.Id)
                         .Where(x=>x.IsActive==true)
                         .FirstOrDefault().MovieName;

        }

        public void Delete(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == Id);
            if (movie != null)
            {
                movie.IsActive = false;
                movie.DeletedDate = DateTime.Now;
                _context.SaveChanges();
            }
        }
    }
}

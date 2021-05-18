using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterestExplorerApp.Dal.Abstract;
using InterestExplorerApp.Entities.Concrete;
using InterestExplorerApp.Entities.DTOs;

namespace InterestExplorerApp.Dal.Concrete.EntityFramework
{
    public class EfMainCategoryDal : IMainCategoryDal
    {
        private InterestExplorerContext _context = new InterestExplorerContext();

      

        // Movie,Series,VideoGame, Book advanced searcing 

        public AdvancedSearchDTO AdvancedSearch(string search)
        {
            var result = new AdvancedSearchDTO();

            result.MovieList = (from m in _context.Movies
                               join c in _context.Categories
                               on m.CategoryId equals c.Id
                               where m.MovieName.Contains(search)
                               select new MovieShortDetailsDTO
                               {
                                   Id = m.Id,
                                   MovieName = m.MovieName,
                                   ImageURL = m.ImageURL,
                                   CategoryName = c.CategoryName,
                                   IMDBScore = m.IMDBScore
                               }).AsNoTracking().ToList();

            result.SerieList = (from s in _context.Series
                                join c in _context.Categories
                                on s.CategoryId equals c.Id
                                where s.SeriesName.Contains(search)
                                select new SeriesShortDetailsDTO
                                {
                                    Id = s.Id,
                                    SeriesName = s.SeriesName,
                                    ImageURL = s.ImageURL,
                                    CategoryName = c.CategoryName,
                                    IMDBScore = s.IMDBScore
                                }).AsNoTracking().ToList();

            result.VideoGameList = (from v in _context.VideoGames
                                    join c in _context.Categories
                                    on v.CategoryId equals c.Id
                                    where v.VideoGameName.Contains(search)
                                    select new VideoGameShortDetailsDTO
                                    {
                                        Id = v.Id,
                                        VideoGameName = v.VideoGameName,
                                        ImageURL = v.ImageURL,
                                        CategoryName = c.CategoryName,
                                        IMDBScore = v.IMDBScore
                                    }).AsNoTracking().ToList();

            result.BookList = (from b in _context.Books
                               join c in _context.Categories
                               on b.CategoryId equals c.Id
                               where b.BookName.Contains(search)
                               select new BookShortDetailsDTO
                               {
                                   Id = b.Id,
                                   BookName = b.BookName,
                                   ImageURL = b.ImageURL,
                                   CategoryName = c.CategoryName
                               }).AsNoTracking().ToList();
            return result;
        }

        public List<MainCategory> GetAll()
        {
            return _context.MainCategories.Include(x=>x.Categories).ToList();
        }

        public int GetTotalMainCategoryCount()
        {
            return _context.MainCategories.Count();
        }
    }
}

using InterestExplorerApp.Dal.Abstract;
using InterestExplorerApp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Dal.Concrete.EntityFramework
{
    public class EfBookDal : IBookDal
    {
        private InterestExplorerContext _context = new InterestExplorerContext();

        public BookLongDetailsDTO GetAllBookDetailsByBookId(int Id)
        {
            var result = (from b in _context.Books
                          join c in _context.Categories
                          on b.CategoryId equals c.Id
                          where b.Id == Id
                          select new BookLongDetailsDTO
                          {
                              BookName = b.BookName,
                              BookDescription = b.BookDescription,
                              AuthorName = b.AuthorName,
                              CategoryName = c.CategoryName,
                              ImageURL = b.ImageURL,
                              PageNumber = b.PageNumber,
                              ReleaseYear = b.ReleaseYear
                          }).SingleOrDefault();
            return result;
        }

        public List<BookShortDetailsDTO> GetAllBookDetailsByCategoryId(int categoryId)
        {
            var result = from b in _context.Books
                         join c in _context.Categories
                         on b.CategoryId equals c.Id
                         where b.CategoryId == categoryId
                         select new BookShortDetailsDTO
                         {
                             Id = b.Id,
                             BookName = b.BookName,
                             CategoryName = c.CategoryName,         
                             ImageURL = b.ImageURL,
                         };
            return result.ToList();
        }
    }
}

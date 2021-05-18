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
    public class EfBookDal : IBookDal
    {
         InterestExplorerContext _context = new InterestExplorerContext();

        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == Id);
            if (book != null)
            {
                book.IsActive = false;
                book.DeletedDate = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public List<Book> GetAll()
        {
            return _context.Books.Where(b => b.IsActive == true).Include(x => x.Category).AsNoTracking().ToList();
        }

        public BookLongDetailsDTO GetAllBookDetailsByBookId(int Id)
        {
            var result = (from b in _context.Books
                          join c in _context.Categories
                          on b.CategoryId equals c.Id
                          where b.Id == Id && b.IsActive == true
                          select new BookLongDetailsDTO
                          {
                              BookName = b.BookName,
                              BookDescription = b.BookDescription,
                              AuthorName = b.AuthorName,
                              CategoryId = b.CategoryId,
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
                         where b.CategoryId == categoryId && b.IsActive == true
                         select new BookShortDetailsDTO
                         {
                             Id = b.Id,
                             BookName = b.BookName,
                             CategoryName = c.CategoryName,         
                             ImageURL = b.ImageURL,
                         };
            return result.AsNoTracking().ToList();
        }

        public Book GetById(int Id)
        {
            return _context.Books.Include(x => x.Category).SingleOrDefault(x => x.Id == Id);
        }

        public string GetLastAddedBookName()
        {
            return _context.Books
                .Where(b=>b.IsActive==true)
                 .OrderByDescending(b => b.Id)
                 .FirstOrDefault().BookName;
        }

        public List<BookShortDetailsDTO> GetLastAddedRecordDetails()
        {
            var result = (from b in _context.Books
                          join c in _context.Categories
                          on b.CategoryId equals c.Id
                          where b.IsActive==true
                          orderby b.CreatedDate descending
                          select new BookShortDetailsDTO
                          {
                              Id = b.Id,
                              BookName = b.BookName,
                              CategoryName = c.CategoryName,
                              ImageURL = b.ImageURL,
                          }).Take(6);

            return result.ToList();
        }

        public List<BookShortDetailsDTO> GetMovieDetailsByFilter(short filter, int categoryId)
        {
            if (filter == 15030)
            {
                var result = from b in _context.Books
                             join c in _context.Categories
                             on b.CategoryId equals c.Id
                             where b.CategoryId == categoryId && b.IsActive == true
                             orderby b.BookName ascending
                             select new BookShortDetailsDTO
                             {
                                 Id = b.Id,
                                 BookName = b.BookName,
                                 CategoryName = c.CategoryName,
                                 ImageURL = b.ImageURL
                             };
                return result.AsNoTracking().ToList();
            }
            else if (filter == 15040)
            {
                var result = from b in _context.Books
                             join c in _context.Categories
                             on b.CategoryId equals c.Id
                             where b.CategoryId == categoryId && b.IsActive == true
                             orderby b.BookName descending
                             select new BookShortDetailsDTO
                             {
                                 Id = b.Id,
                                 BookName = b.BookName,
                                 CategoryName = c.CategoryName,
                                 ImageURL = b.ImageURL
                             };
                return result.AsNoTracking().ToList();
            }
            else if (filter == 15050)
            {
                var result = from b in _context.Books
                             join c in _context.Categories
                             on b.CategoryId equals c.Id
                             where b.CategoryId == categoryId && b.IsActive == true
                             orderby b.ReleaseYear descending
                             select new BookShortDetailsDTO
                             {
                                 Id = b.Id,
                                 BookName = b.BookName,
                                 CategoryName = c.CategoryName,
                                 ImageURL = b.ImageURL
                             };
                return result.AsNoTracking().ToList();
            }
            else if (filter == 15060)
            {
                var result = from b in _context.Books
                             join c in _context.Categories
                             on b.CategoryId equals c.Id
                             where b.CategoryId == categoryId &&  b.IsActive == true
                             orderby b.ReleaseYear ascending
                             select new BookShortDetailsDTO
                             {
                                 Id = b.Id,
                                 BookName = b.BookName,
                                 CategoryName = c.CategoryName,
                                 ImageURL = b.ImageURL
                             };
                return result.AsNoTracking().ToList();
            }
            return null;
        }

        public List<BookShortDetailsDTO> GetRandomBookDetailsByCategoryId(int categoryId)
        {
            var result = (from b in _context.Books
                          join c in _context.Categories
                          on b.CategoryId equals c.Id
                          where b.CategoryId == categoryId && b.IsActive==true
                          orderby Guid.NewGuid()
                          select new BookShortDetailsDTO
                          {
                              Id = b.Id,
                              BookName = b.BookName,
                              CategoryName = c.CategoryName,
                              ImageURL = b.ImageURL
                          }).Take(6);
            return result.AsNoTracking().ToList();
        }

        public int GetTotalBookCount()
        {
            return _context.Books.Where(b=>b.IsActive==true).Count();
        }

        public List<Book> SearchByBookName(string search)
        {
            return _context.Books.Include(x => x.Category).Where(x => x.BookName.Contains(search) && x.IsActive == true).AsNoTracking().ToList();
        }

        public void Update(Book book)
        {
            _context.Books.AddOrUpdate(book);
            _context.SaveChanges();
        }
    }
}

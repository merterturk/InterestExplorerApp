﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterestExplorerApp.Bll.Abstract;
using InterestExplorerApp.Dal.Abstract;
using InterestExplorerApp.Entities.Concrete;
using InterestExplorerApp.Entities.DTOs;

namespace InterestExplorerApp.Bll.Concrete
{
    public class BookManager : IBookService
    {
        IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public List<BookShortDetailsDTO> GetAllBookDetailsByCategoryId(int categoryId)
        {
            return _bookDal.GetAllBookDetailsByCategoryId(categoryId);
        }

        public BookLongDetailsDTO GetBookDetailsByBookId(int Id)
        {
            return _bookDal.GetBookDetailsByBookId(Id);
        }

        public void Add(Book book)
        {
            _bookDal.Add(book);
        }

        public List<BookShortDetailsDTO> GetLastAddedRecordDetails()
        {
            return _bookDal.GetLastAddedRecordDetails();
        }

        public List<BookShortDetailsDTO> GetMovieDetailsByFilter(short filter, int categoryId)
        {
            return _bookDal.GetMovieDetailsByFilter(filter, categoryId);
        }

        public List<BookShortDetailsDTO> GetRandomBookDetailsByCategoryId(int categoryId)
        {
            return _bookDal.GetRandomBookDetailsByCategoryId(categoryId);
        }

        public int GetTotalBookCount()
        {
            return _bookDal.GetTotalBookCount();
        }

        public string GetLastAddedBookName()
        {
            return _bookDal.GetLastAddedBookName();
        }

        public Book GetById(int Id)
        {
            return _bookDal.GetById(Id);
        }

        public List<Book> GetAll()
        {
            return _bookDal.GetAll();
        }

        public void Update(Book book)
        {
            _bookDal.Update(book);
        }

        public void Delete(int Id)
        {
            _bookDal.Delete(Id);
        }

        public List<Book> SearchByBookName(string search)
        {
            return _bookDal.SearchByBookName(search);
        }
    }
    
}

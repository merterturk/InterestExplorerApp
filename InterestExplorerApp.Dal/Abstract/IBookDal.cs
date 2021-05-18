﻿using InterestExplorerApp.Entities.Concrete;
using InterestExplorerApp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Dal.Abstract
{
    public interface IBookDal
    {
        Book GetById(int Id);

        List<Book> GetAll();

        void Add(Book book);

        void Update(Book book);

        void Delete(int Id);

        List<BookShortDetailsDTO> GetAllBookDetailsByCategoryId(int categoryId);

        BookLongDetailsDTO GetAllBookDetailsByBookId(int Id);

        List<BookShortDetailsDTO> GetLastAddedRecordDetails();

        List<BookShortDetailsDTO> GetMovieDetailsByFilter(short filter, int categoryId);

        List<BookShortDetailsDTO> GetRandomBookDetailsByCategoryId(int categoryId);

        List<Book> SearchByBookName(string search);

        int GetTotalBookCount();

        string GetLastAddedBookName();
    }
}

﻿using InterestExplorerApp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Dal.Abstract
{
    public interface IBookDal
    {
        List<BookShortDetailsDTO> GetAllBookDetailsByCategoryId(int categoryId);

        BookLongDetailsDTO GetAllBookDetailsByBookId(int Id);

        List<BookShortDetailsDTO> GetLastAddedRecordDetails();

        List<BookShortDetailsDTO> GetMovieDetailsByFilter(short filter, int categoryId);

        List<BookShortDetailsDTO> GetRandomBookDetailsByCategoryId(int categoryId);

        int GetTotalBookCount();

        string GetLastAddedBookName();
    }
}

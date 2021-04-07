using InterestExplorerApp.Entities.Concrete;
using InterestExplorerApp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Bll.Abstract
{
    public interface IBookService
    {
        void Add(Book book);

        List<BookShortDetailsDTO> GetAllBookDetailsByCategoryId(int categoryId);

        BookLongDetailsDTO GetAllBookDetailsByBookId(int Id);

        List<BookShortDetailsDTO> GetLastAddedRecordDetails();
    }
}

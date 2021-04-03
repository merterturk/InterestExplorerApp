using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterestExplorerApp.Entities.DTOs;
namespace InterestExplorerApp.Dal.Abstract
{
    public interface IMovieDal
    {
        List<MovieShortDetailsDTO> GetAllMovieDetailsByCategoryId(int categoryId);

        MovieLongDetailsDTO GetMovieDetailsByMovieId(int Id);

        List<MovieShortDetailsDTO> GetLastAddedRecordDetails();
    }
}

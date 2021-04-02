using System;
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
    public class MovieManager : IMovieService
    {
        private IMovieDal _movieDal;

        public MovieManager(IMovieDal movieDal)
        {
            _movieDal = movieDal;
        }
        public List<MovieShortDetailsDTO> GetAllMovieDetailsByCategoryId(int categoryId)
        {
            return _movieDal.GetAllMovieDetailsByCategoryId(categoryId);
        }

        public MovieLongDetailsDTO GetAllMovieDetailsByMovieId(int Id)
        {
            return _movieDal.GetAllMovieDetailsByMovieId(Id);
        }

        public List<MovieShortDetailsDTO> GetLastAddedRecordDetails()
        {
            return _movieDal.GetLastAddedRecordDetails();
        }
    }
}

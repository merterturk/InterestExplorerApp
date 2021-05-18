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
        IMovieDal _movieDal;

        public MovieManager(IMovieDal movieDal)
        {
            _movieDal = movieDal;
        }
        public List<MovieShortDetailsDTO> GetAllMovieDetailsByCategoryId(int categoryId)
        {
            return _movieDal.GetAllMovieDetailsByCategoryId(categoryId);
        }

        public MovieLongDetailsDTO GetMovieDetailsByMovieId(int Id) => _movieDal.GetMovieDetailsByMovieId(Id);


        public List<MovieShortDetailsDTO> GetLastAddedRecordDetails() => _movieDal.GetLastAddedRecordDetails();


        public List<MovieShortDetailsDTO> GetHighestImdbScore() => _movieDal.GetHighestImdbScore();
       

        public List<MovieShortDetailsDTO> GetHighestImdbScoreByCategoryId(int categoryId)
        {
            return _movieDal.GetHighestImdbScoreByCategoryId(categoryId);
        }
        public List<MovieShortDetailsDTO> GetMovieDetailsByFilter(short filter,int categoryId)
        {

            return _movieDal.GetMovieDetailsByFilter(filter,categoryId);
        }

        public List<MovieShortDetailsDTO> GetRandomMovieDetailsByCategoryId(int categoryId)
        {
            return _movieDal.GetRandomMovieDetailsByCategoryId(categoryId);
        }

        public List<Movie> GetAll()
        {
            return _movieDal.GetAll();
        }

        public Movie GetById(int Id)
        {
            return _movieDal.GetById(Id);
        }

        public void Update(Movie movie)
        {
            _movieDal.Update(movie);
        }

        public List<Movie> SearchByMovieName(string search)
        {
          return _movieDal.SearchByMovieName(search);
        }

        public void Add(Movie movie)
        {
             _movieDal.Add(movie);
        }

        public int GetTotalMovieCount()
        {
            return _movieDal.GetTotalMovieCount();
        }

        public string GetLastAddedMovieName()
        {
            return _movieDal.GetLastAddedMovieName();
        }

        public void Delete(int Id)
        {
            _movieDal.Delete(Id);
        }
    }
}

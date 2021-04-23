using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterestExplorerApp.Entities.Concrete;
using InterestExplorerApp.Entities.DTOs;
namespace InterestExplorerApp.Dal.Abstract
{
    public interface IMovieDal
    {
        Movie GetById(int Id);

        List<Movie> GetAll();

        void Add(Movie movie);

        void Update(Movie movie);

        void Delete(int Id);

        List<MovieShortDetailsDTO> GetAllMovieDetailsByCategoryId(int categoryId);

        MovieLongDetailsDTO GetMovieDetailsByMovieId(int Id);

        List<MovieShortDetailsDTO> GetLastAddedRecordDetails();

        List<MovieShortDetailsDTO> GetHighestImdbScore();

        List<MovieShortDetailsDTO> GetHighestImdbScoreByCategoryId(int categoryId);

        List<MovieShortDetailsDTO> GetMovieDetailsByFilter(short filter,int categoryId);

        List<MovieShortDetailsDTO> GetRandomMovieDetailsByCategoryId(int categoryId);

        List<Movie> SearchByMovieName(string search);

        int GetTotalMovieCount();

        string GetLastAddedMovieName();
    }
}

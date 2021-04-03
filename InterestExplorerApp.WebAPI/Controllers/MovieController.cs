using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InterestExplorerApp.Bll.Abstract;
using InterestExplorerApp.Entities.DTOs;
namespace InterestExplorerApp.WebAPI.Controllers
{
    public class MovieController : ApiController
    {
        IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IEnumerable<MovieShortDetailsDTO> GetLastAddedMovieDetails() // returned six Movie
        {
            return _movieService.GetLastAddedRecordDetails();
        }
        [HttpGet]
        public MovieLongDetailsDTO GetMovieByMovieId(int movieId)
        {
            return _movieService.GetMovieDetailsByMovieId(movieId);
        }
        [HttpGet]
        public IEnumerable<MovieShortDetailsDTO> GetAllMovieDetailsByCategoryId(int categoryId)
        {
            return _movieService.GetAllMovieDetailsByCategoryId(categoryId);
        }
    }
}

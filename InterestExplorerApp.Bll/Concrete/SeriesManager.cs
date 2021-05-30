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
    public class SeriesManager : ISeriesService
    {
        ISeriesDal _seriesDal;

        public SeriesManager(ISeriesDal seriesDal)
        {
            _seriesDal = seriesDal;
        }

        public void Add(Series series)
        {
            _seriesDal.Add(series);
        }

        public void Delete(int Id)
        {
            _seriesDal.Delete(Id);
        }

        public List<Series> GetAll()
        {
            return _seriesDal.GetAll();
        }

        public List<SeriesShortDetailsDTO> GetAllSeriesDetailsByCategoryId(int categoryId)
        {
            return _seriesDal.GetAllSeriesDetailsByCategoryId(categoryId);
        }

        public SeriesLongDetailsDTO GetSeriesDetailsBySeriesId(int Id)
        {
            return _seriesDal.GetSeriesDetailsBySeriesId(Id);
        }

        public Series GetById(int Id)
        {
            return _seriesDal.GetById(Id);
        }

        public List<SeriesShortDetailsDTO> GetHighestImdbScore()
        {
            return _seriesDal.GetHighestImdbScore();
        }

        public List<SeriesShortDetailsDTO> GetHighestImdbScoreByCategoryId(int categoryId)
        {
            return _seriesDal.GetHighestImdbScoreByCategoryId(categoryId);
        }

        public List<SeriesShortDetailsDTO> GetLastAddedRecordDetails()
        {
            return _seriesDal.GetLastAddedRecordDetails();
        }

        public string GetLastAddedSeriesName()
        {
            return _seriesDal.GetLastAddedSeriesName(); 
        }

        public List<SeriesShortDetailsDTO> GetRandomSeriesDetailsByCategoryId(int categoryId)
        {
            return _seriesDal.GetRandomSeriesDetailsByCategoryId(categoryId);
        }

        public List<SeriesShortDetailsDTO> GetSeriesDetailsByFilter(short filter, int categoryId)
        {
            return _seriesDal.GetSeriesDetailsByFilter(filter, categoryId);
        }

        public int GetTotalSeriesCount()
        {
            return _seriesDal.GetTotalSeriesCount(); 
        }

        public List<Series> SearchBySeriesName(string search)
        {
            return _seriesDal.SearchBySeriesName(search);
        }

        public void Update(Series series)
        {
             _seriesDal.Update(series);
        }
    }
}

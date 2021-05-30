using InterestExplorerApp.Entities.Concrete;
using InterestExplorerApp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Dal.Abstract
{
   public interface ISeriesDal
    {
        Series GetById(int Id);

        List<Series> GetAll();

        void Add(Series series);

        void Update(Series series);

        void Delete(int Id);

        List<SeriesShortDetailsDTO> GetAllSeriesDetailsByCategoryId(int categoryId);

        SeriesLongDetailsDTO GetSeriesDetailsBySeriesId(int Id);

        List<SeriesShortDetailsDTO> GetLastAddedRecordDetails();

        List<SeriesShortDetailsDTO> GetHighestImdbScore();

        List<SeriesShortDetailsDTO> GetHighestImdbScoreByCategoryId(int categoryId);

        List<SeriesShortDetailsDTO> GetSeriesDetailsByFilter(short filter, int categoryId);

        List<SeriesShortDetailsDTO> GetRandomSeriesDetailsByCategoryId(int categoryId);

        List<Series> SearchBySeriesName(string search);

        int GetTotalSeriesCount();

        string GetLastAddedSeriesName();
    }
}

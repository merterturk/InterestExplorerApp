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
        List<SeriesShortDetailsDTO> GetAllSeriesDetailsByCategoryId(int categoryId);

        SeriesLongDetailsDTO GetAllSeriesDetailsBySeriesId(int Id);

        List<SeriesShortDetailsDTO> GetLastAddedRecordDetails();

        List<SeriesShortDetailsDTO> GetHighestImdbScore();

        List<SeriesShortDetailsDTO> GetHighestImdbScoreByCategoryId(int categoryId);

        List<SeriesShortDetailsDTO> GetSeriesDetailsByFilter(short filter, int categoryId);

        List<SeriesShortDetailsDTO> GetRandomSeriesDetailsByCategoryId(int categoryId);

        int GetTotalSeriesCount();

        string GetLastAddedSeriesName();
    }
}

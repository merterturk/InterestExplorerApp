using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterestExplorerApp.Entities.DTOs;
namespace InterestExplorerApp.Bll.Abstract
{
   public interface ISeriesService
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

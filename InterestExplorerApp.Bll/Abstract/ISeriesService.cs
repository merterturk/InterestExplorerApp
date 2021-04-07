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
    }
}

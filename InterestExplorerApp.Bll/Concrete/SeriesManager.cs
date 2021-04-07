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
       private ISeriesDal _seriesDal;

        public SeriesManager(ISeriesDal seriesDal)
        {
            _seriesDal = seriesDal;
        }

        public List<SeriesShortDetailsDTO> GetAllSeriesDetailsByCategoryId(int categoryId)
        {
            return _seriesDal.GetAllSeriesDetailsByCategoryId(categoryId);
        }

        public SeriesLongDetailsDTO GetAllSeriesDetailsBySeriesId(int Id)
        {
            return _seriesDal.GetAllSeriesDetailsBySeriesId(Id);
        }

        public List<SeriesShortDetailsDTO> GetHighestImdbScore()
        {
            return _seriesDal.GetHighestImdbScore();
        }

        public List<SeriesShortDetailsDTO> GetLastAddedRecordDetails()
        {
            return _seriesDal.GetLastAddedRecordDetails();
        }
    }
}

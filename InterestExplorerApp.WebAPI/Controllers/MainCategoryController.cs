using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InterestExplorerApp.Bll.Abstract;
namespace InterestExplorerApp.WebAPI.Controllers
{
    public class MainCategoryController : ApiController
    {
        IMainCategoryService _mainCategoryService;

        public MainCategoryController(IMainCategoryService mainCategoryService)
        {
            _mainCategoryService = mainCategoryService;
        }

        
    }
}

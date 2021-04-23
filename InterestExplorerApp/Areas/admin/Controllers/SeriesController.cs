using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterestExplorerApp.WebUI.Areas.admin.Controllers
{
    public class SeriesController : Controller
    {
        // GET: admin/Series
        public ActionResult Index()
        {
            return View();
        }
    }
}
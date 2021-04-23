using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterestExplorerApp.WebUI.Areas.admin.Controllers
{
    public class VideoGameController : Controller
    {
        // GET: admin/VideoGame
        public ActionResult Index()
        {
            return View();
        }
    }
}
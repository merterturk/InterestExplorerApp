using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterestExplorerApp.Areas.admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: admin/Anasayfa
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Deneme()
        {
            return View();
        }
   
    }
}
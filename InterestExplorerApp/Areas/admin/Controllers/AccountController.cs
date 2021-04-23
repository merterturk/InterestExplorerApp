using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterestExplorerApp.WebUI.Areas.admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: admin/Account
        public ActionResult Login()
        {
            return View();
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterestExplorerApp.WebUI.Areas.admin.Controllers
{
    public class BookController : Controller
    {
        // GET: admin/Book
        public ActionResult Index()
        {
            return View();
        }
    }
}
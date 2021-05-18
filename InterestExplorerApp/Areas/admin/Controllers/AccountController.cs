using InterestExplorerApp.Bll.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace InterestExplorerApp.WebUI.Areas.admin.Controllers
{
    public class AccountController : Controller
    {
        IAdminService _adminService;
        public AccountController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string userName,string password)
        {
          if(!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                var admin = _adminService.Login(userName, password);

                if (admin != null)
                {
                    FormsAuthentication.SetAuthCookie(admin.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Kullanıcı adı veya şifre yanlış";
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
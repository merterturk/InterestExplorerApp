using System.Web.Mvc;

namespace InterestExplorerApp.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { area = "admin", controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "InterestExplorerApp.WebUI.Areas.admin.Controllers" }

            );
        
        }
    }
}
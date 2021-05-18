using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace InterestExplorerApp.WebUI.Helper
{
    public static class FileHelper
    {
        public static string Add(HttpPostedFileBase file, string type)
        {
            if (file.ContentLength > 0)
            {
                string fileName = Path.GetFileName(file.FileName);
                string fileExtension = Path.GetExtension(file.FileName);
                fileName = Guid.NewGuid().ToString();
                string path = "~/Content/img/" + type + "/" + fileName + fileExtension;
                file.SaveAs(HttpContext.Current.Server.MapPath(path));
                return $"/Content/img/{type}/{fileName}{fileExtension}";
            }
            return null;
        }
     
    }
}
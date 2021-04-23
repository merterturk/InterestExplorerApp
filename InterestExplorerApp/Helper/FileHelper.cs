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
                string dosyaadi = Path.GetFileName(file.FileName);
                string dosyayolu = Path.GetExtension(file.FileName);
                dosyaadi = Guid.NewGuid().ToString();
                string yol = "~/Content/img/" + type + "/" + dosyaadi + dosyayolu;
                file.SaveAs(HttpContext.Current.Server.MapPath(yol));
                return $"/Content/img/{type}/{dosyaadi}{dosyayolu}";
            }
            return null;
        }
    }
}
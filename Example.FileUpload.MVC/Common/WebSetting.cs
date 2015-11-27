using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Example.FileUpload.MVC.Common
{
    public static class WebSetting
    {
        public static string DefaultUploadPath
        {
            get {
                if (!System.IO.Directory.Exists(HttpContext.Current.Request.MapPath("~/UploadFiles")))
                    System.IO.Directory.CreateDirectory(HttpContext.Current.Request.MapPath("~/UploadFiles"));
                return HttpContext.Current.Request.MapPath("~/UploadFiles");            
            }
            set { DefaultUploadPath = value; }
        }// = HttpContext.Current.Request.MapPath("~/UploadFile");
    }
}
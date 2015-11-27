using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example.FileUpload.MVC.Controllers
{
    public class SingleUploadController : Controller
    {
        // GET: SingleUpload
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                TempData["UploadMsg"] = "上传失败";
            }
            else
            {
                string ext = Path.GetExtension(file.FileName);
                string fileName = Guid.NewGuid().ToString() + ext;
                string savePath = Path.Combine(Common.WebSetting.DefaultUploadPath, fileName);
                file.SaveAs(savePath);
                TempData["UploadMsg"] = System.IO.File.Exists(savePath) ? "上传成功，保存在：" + savePath : "上传失败";
            }
            return View("Index");
        }
    }
}
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
        public ActionResult Index(int id)
        {
            return View("~/Views/SingleUpload/Index" + id + ".cshtml");
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
                TempData["UploadMsg"] = System.IO.File.Exists(savePath) ? "上传成功，文件名为：" + fileName : "上传失败";
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult MultiUpload(IEnumerable<HttpPostedFileBase> files)
        {
            string str="";
            if (files != null)
            {
                str = "";
                string ext = "", fileName = "", savePath;
                int i = 0;
                foreach (var file in files)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        //判断文件大小 file.ContentLength
                        ext = Path.GetExtension(file.FileName);
                        fileName = Guid.NewGuid().ToString() + ext;
                        savePath = Path.Combine(Common.WebSetting.DefaultUploadPath, fileName);
                        file.SaveAs(savePath);
                        i++;
                        str += (System.IO.File.Exists(savePath) ? "第" + i + "个文件上传成功，文件名为：" + fileName : "第" + i + "个文件上传失败") + "<br/>";
                    }
                }
            }
            else
            {

                str = "<b>请上传文件</b>";
            }
            TempData["UploadMsg"]=str;
            return Redirect("/SingleUpload/index/2");
        }
    }
}
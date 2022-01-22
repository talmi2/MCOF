using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCupOverflows.Models;
using MyCupOverflows.ViewModel;
using MyCupOverflows.Dal;
using System.Data.Entity;
using System.IO;

namespace MyCupOverflows.Controllers
{
    public class ProductUploadController : Controller
    {
        // GET: ProductUpload
        public ActionResult NewProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadFiles(Product MyProduct, HttpPostedFileBase Picture)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {

                    ProductDal pdal = new ProductDal();
                    MyProduct.Picture = Picture.FileName;
                    pdal.PRODUCTS.Add(MyProduct);
                    pdal.SaveChanges();

                }
                try
                {

                    //Method 2 Get file details from HttpPostedFileBase class    

                    if (Picture != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(Picture.FileName));
                        Picture.SaveAs(path);
                    }
                    ViewBag.FileStatus = "File uploaded successfully.";
                }
                catch (Exception)
                {
                    ViewBag.FileStatus = "Error while file uploading."; ;
                }
            }
            return RedirectToAction("NewProduct");
        }
    }
}
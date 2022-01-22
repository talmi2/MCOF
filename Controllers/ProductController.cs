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
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult GetList()
        {
            using (ProductDal db = new ProductDal())
            {
                List<Product> empList = db.PRODUCTS.ToList<Product>();
                return Json(new { data = empList }, JsonRequestBehavior.AllowGet);
            }
        }


        /*public ActionResult DisplayMovieGallery(MovieViewModel model)
        {
            ProductDal dal = new ProductDal();
            MovieViewModel mvm = new MovieViewModel();
            List<Movie> movies = dal.MOVIES.ToList();
            mvm.Movie = new Movie();
            mvm.Movies = movies;
            return View(mvm);
        }

        [HttpPost]
        public ActionResult DisplayMovieGallery()
        {
            ProductDal dal = new ProductDal();
            if (ModelState.IsValid)
            {
                var data = dal.MOVIES.ToList();
                return View();
            }
            else
                return View("Movie");
        }*/


        public ActionResult ManageProduct(ProductViewModel model)
        {
            ProductDal dal = new ProductDal();
            ProductViewModel mvm = new ProductViewModel();
            List<Product> products = dal.PRODUCTS.ToList();
            mvm.Products = new Product();
            mvm.Productss = products;
            return View(mvm);
        }

        [HttpPost]
        public ActionResult ManageProduct()
        {
            ProductDal dal = new ProductDal();
            if (ModelState.IsValid)
            {
                var data = dal.PRODUCTS.ToList();
                return View();
            }
            else

                return View("Product/ManageProduct");
        }



        [HttpGet]
        public ActionResult Save(string id)
        {
            using (ProductDal dc = new ProductDal())
            {
                var v = dc.PRODUCTS.Where(a => a.Id == id).FirstOrDefault();
                return View(v);
            }
        }

        [HttpPost]
        public ActionResult Save(Product emp)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (ProductDal dc = new ProductDal())
                {
                    if (emp.Id != null)
                    {
                        //Edit 
                        var v = dc.PRODUCTS.Where(a => a.Id == emp.Id).FirstOrDefault();
                        if (v != null)
                        {
                            v.Name = emp.Name;
                            v.Category = emp.Category;
                            v.Picture = emp.Picture;
                            v.Price = emp.Price;
                            v.Specification = emp.Specification;
                            v.RestrictedAge = emp.RestrictedAge;
                        }
                    }
                    else
                    {
                        //Save
                        dc.PRODUCTS.Add(emp);
                    }
                    dc.SaveChanges();
                    status = true;
                    return View("ManageProduct");

                }
            }
            return new JsonResult { Data = new { status = status } };
        }


        [HttpGet]
        public ActionResult Delete(string id)
        {
            using (ProductDal dc = new ProductDal())
            {
                var v = dc.PRODUCTS.Where(a => a.Id == id).FirstOrDefault();
                if (v != null)
                {
                    return View(v);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteProduct(string id)
        {

            using (ProductDal dc = new ProductDal())
            {
                var v = dc.PRODUCTS.Where(a => a.Id == id).FirstOrDefault();
                if (v != null)
                {
                    dc.PRODUCTS.Remove(v);
                    dc.SaveChanges();
                    return View("ManageProduct");

                }
            }
            return View("ManageProduct");
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            Product obj = new Product();
            obj.Delete(id);
            return RedirectToAction("DisplayProductGallery");
        }
    }
}
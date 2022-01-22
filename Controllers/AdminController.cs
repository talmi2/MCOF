using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCupOverflows.Models;
using MyCupOverflows.Dal;
using MyCupOverflows.ViewModel;
using System.Security.Cryptography;

namespace MyCupOverflows.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult GetList()
        {
            using (BranchDal db = new BranchDal())
            {
                List<Branch> empList = db.Branches.ToList<Branch>();
                return Json(new { data = empList }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SlideMenu()
        {

            List<MenuItem> list = new List<MenuItem>();

            list.Add(new MenuItem { Link = "Product/ManageProduct", LinkName = "ManageProduct" });
            list.Add(new MenuItem { Link = "Admin/ManageBranch", LinkName = "ManageBranch" });
            list.Add(new MenuItem { Link = "Admin/ManageSeat", LinkName = "ManageSeat" });
            list.Add(new MenuItem { Link = "Admin/Admin", LinkName = "Create new worker" });



            return PartialView("SlideMenu", list);
        }

        public ActionResult Admin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Admin(Admin obj)

        {
            if (ModelState.IsValid)
            {
                AdminDal AD = new AdminDal();
                AD.Admin.Add(obj);
                AD.SaveChanges();
                return RedirectToAction("SlideMenu", "Admin");

            }
            return View("Admin", obj);
        }

        public ActionResult ManageSeat()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ManageSeat(Seat obj)

        {
            if (ModelState.IsValid)
            {
                SeatDal dal = new SeatDal();
                BranchDal BrDal = new BranchDal();
                if (BrDal.Branches.Where(s => s.Id.Equals(obj.Branch)).Count() > 0)
                {
                    dal.Seats.Add(obj);
                    dal.SaveChanges();
                    return View("SlideMenu");

                }
                else
                {
                    return RedirectToAction("ManageSeat");
                }

            }
            return View("SlideMenu");

        }

        public ActionResult ManageBranch()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ManageBranch(Branch obj)

        {
            if (ModelState.IsValid)
            {

                BranchDal BrDal = new BranchDal();

                BrDal.Branches.Add(obj);
                BrDal.SaveChanges();

                return RedirectToAction("BranchGallery");

            }
            return View();
        }


        public ActionResult BranchGallery(ProductViewModel model)
        {
            BranchDal BranchDal = new BranchDal();
            BranchViewModel mvm = new BranchViewModel();
            List<Branch> BRANCHES = BranchDal.Branches.ToList();
            mvm.Branch = new Branch();
            mvm.Branches = BRANCHES;
            return View(mvm);
        }

        [HttpPost]
        public ActionResult BranchGallery()
        {
            BranchDal dal = new BranchDal();
            if (ModelState.IsValid)
            {
                var data = dal.Branches.ToList();
                return View();
            }
            else

                return View("Admin/BranchGallery");
        }

        [HttpGet]
        public ActionResult Save(string id)
        {
            using (BranchDal dc = new BranchDal())
            {
                var v = dc.Branches.Where(a => a.Id == id).FirstOrDefault();
                return View(v);
            }
        }

        [HttpPost]
        public ActionResult Save(Branch emp)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (BranchDal dc = new BranchDal())
                {
                    if (emp.Id != null)
                    {
                        //Edit 
                        var v = dc.Branches.Where(a => a.Id == emp.Id).FirstOrDefault();
                        if (v != null)
                        {

                            v.NumberOfseat = emp.NumberOfseat;
                        }
                    }
                    else
                    {
                        //Save
                        dc.Branches.Add(emp);
                    }
                    dc.SaveChanges();
                    status = true;
                    return View("BranchGallery");

                }
            }
            return new JsonResult { Data = new { status = status } };
        }


        [HttpGet]
        public ActionResult Delete(string id)
        {
            using (BranchDal dc = new BranchDal())
            {
                var v = dc.Branches.Where(a => a.Id == id).FirstOrDefault();
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

            using (BranchDal dc = new BranchDal())
            {
                var v = dc.Branches.Where(a => a.Id == id).FirstOrDefault();
                if (v != null)
                {
                    dc.Branches.Remove(v);
                    dc.SaveChanges();
                    return View("BranchGallery");

                }
            }
            return View("BranchGallery");
        }

        public ActionResult GetListSeat()
        {
            using (SeatDal db = new SeatDal())
            {
                List<Seat> empList = new List<Seat>();
                for (int i = 0; i < db.Seats.ToList<Seat>().Count(); i++)
                {
                    if (db.Seats.ToList<Seat>()[i].Reserve == false)
                    {
                        empList.Add(db.Seats.ToList<Seat>()[i]);
                    }

                }
                return Json(new { data = empList }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
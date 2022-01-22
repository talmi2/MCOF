using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MyCupOverflows.Models;
using MyCupOverflows.ViewModel;
using MyCupOverflows.Dal;
using System.Data.Entity;
using System.IO;

namespace MyCupOverflows.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult BookingSeat()
        {
            return View();
        }

        public ActionResult GetImage(string id)
        {
            var dir = Server.MapPath("/Content/Images");
            var path = Path.Combine(dir, id + ".jpg");
            return base.File(path, "image/jpeg");
        }

        public ActionResult ProductGallery(ProductViewModel model)
        {
            ProductDal dal = new ProductDal();
            ProductViewModel mvm = new ProductViewModel();
            List<Product> movies = dal.PRODUCTS.ToList();
            mvm.Products = new Product();
            mvm.Productss = movies;
            return View(mvm);
        }

        [HttpPost]
        public ActionResult ProductGallery()
        {
            ProductDal dal = new ProductDal();
            if (ModelState.IsValid)
            {
                var data = dal.PRODUCTS.ToList();
                return View();
            }
            else

                return View("ProductGallery");
        }


        public ActionResult BookOrder(string id)
        {
            Orders mvm = new Orders();
            ReservationCart itemCart = new ReservationCart();
            ProductDal dal = new ProductDal();
            SeatDal seatDal = new SeatDal();
            var itemSeat2 = seatDal.Seats.Where(a => a.Id == id).FirstOrDefault();
            var itemsMovie3 = dal.PRODUCTS.Where(a => a.Branch == itemSeat2.Branch).FirstOrDefault();


            return View(mvm);
        }

        [HttpPost]
        public ActionResult BookOrder(Orders obj)
        {

            if (ModelState.IsValid)
            {

                OrdersDal dal = new OrdersDal();
                SeatDal seatDal = new SeatDal();
                if (seatDal.Seats.Where(s => s.Number.Equals(obj.Seat)).Count() > 0)
                {
                    dal.OrdersList.Add(obj);
                    dal.SaveChanges();
                    return View("DetailsOrders", obj);
                }
                else
                {
                    return RedirectToAction("BookOrder");
                }

            }
            return View("ProductGallery");

        }

        public ActionResult DetailsOrders()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DetailsOrders(ReservationCart obj)
        {
            if (ModelState.IsValid)
            {
                ReservationCartDal resDal = new ReservationCartDal();
                resDal.reservationCarts.Add(obj);
                resDal.SaveChanges();
                return View("ShoppingCart", "Cart");
            }

            return View();

        }

        [HttpGet]
        public ActionResult SeatGalleryUser(string id)
        {
            SeatDal dal = new SeatDal();
            ProductDal dal2 = new ProductDal();
            UserSeatViewModel mvm2 = new UserSeatViewModel();
            SeatViewModel mvm = new SeatViewModel();
            List<Seat> Seatss = new List<Seat>();
            var item = dal2.PRODUCTS.Where(a => a.Id == id).FirstOrDefault();
            for (int i = 0; i < dal.Seats.ToList().Count(); i++)
            {
                if (dal.Seats.ToList()[i].Branch == item.Branch)
                {
                    Seatss.Add(dal.Seats.ToList()[i]);
                }

            }
            mvm2.Seat = new Seat();
            mvm2.Seats = Seatss;
            return View(mvm2);
        }

        [HttpPost]
        public ActionResult SeatGalleryUser()
        {
            SeatDal dal = new SeatDal();
            if (ModelState.IsValid)
            {
                var data = dal.Seats.ToList();
                return View();
            }
            else

                return View("Home/ProductGallery");
        }

        [HttpGet]
        public ActionResult Reserve(string id)
        {
            using (SeatDal dc = new SeatDal())
            {
                var v = dc.Seats.Where(a => a.Id == id).FirstOrDefault();
                return View(v);
            }
        }

        [HttpPost]
        public ActionResult Reserve(Seat emp)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (SeatDal dc = new SeatDal())
                {
                    if (emp.Id != null && emp.Reserve == false)
                    {
                        //Edit 
                        var v = dc.Seats.Where(a => a.Id == emp.Id).FirstOrDefault();
                        if (v != null)
                        {

                            v.Reserve = true;
                        }
                    }
                    else
                    {
                        //Save
                        return View("AlreadyOccuped");
                    }
                    dc.SaveChanges();

                    status = true;

                    OrdersDal dal2 = new OrdersDal();
                    var item = dal2.OrdersList.Where(a => a.Branch == emp.Branch && a.DateReservation == emp.Date).FirstOrDefault();
                    //return View("BookOrder");

                    return RedirectToAction("BookOrder", new { Id = emp.Id });

                }
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}
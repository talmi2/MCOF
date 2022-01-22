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
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DisplayOrders(OrdersViewModel model)
        {
            OrdersDal dal = new OrdersDal();
            OrdersViewModel mvm = new OrdersViewModel();
            List<Orders> ticketss = dal.OrdersList.ToList();
            mvm.Orders = new Orders();
            mvm.OrdersList = ticketss;
            return View(mvm);
        }

        [HttpPost]
        public ActionResult ManageProduct()
        {
            OrdersDal dal = new OrdersDal();
            if (ModelState.IsValid)
            {
                var data = dal.OrdersList.ToList();
                return View();
            }
            else

                return View("Orders/DisplayOrders");
        }
    }
}
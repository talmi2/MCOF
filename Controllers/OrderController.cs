using MCOF.Models;
using MCOF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCOF.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult GetOrder()
        {
            var order1 = new Order() { OrderID = 1, BranchID = 1, bID = 4, orderDate = default(DateTime) };
            var products = new List<Product>()
            {
                new Product()
                {
                    PID = 1,
                    pName = "Classic",
                    pComment = "Classic coffee of the house",
                    pRestrictedAge = false,
                    pPrice = 3,
                    pType = "Drink"

                },
                new Product()
                {
                    PID = 2,
                    pName = "Machiatto",
                    pComment = "Milky and sweety coffee",
                    pRestrictedAge = false,
                    pPrice = 7,
                    pType = "Drink"
                },
                new Product()
                {
                    PID = 3,
                    pName = "Martini",
                    pComment = "Rhum and olive with menthe",
                    pRestrictedAge = true,
                    pPrice = 15,
                    pType = "Drink"
                }

            };
            var viewModel = new OrderViewModel()
            {
                Order = order1,
                Product = products
            };

            return View(viewModel);
        }
        public ActionResult SingleOrder()
        {
            return View();
        }
        public ActionResult EditOrder(int id)
        {
            return Content("Order ID " + id);
        }
        [Route("Order/byid/{id}")]
        public ActionResult ByOrderId(int id)
        {
            return Content("Id: " + id);
        }
    }
}
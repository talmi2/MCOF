using MCOF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCOF.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Contact()
        {
            
            return View();
        }
        public ActionResult GetCustomer()
        {
            List<Customer> customers = new List<Customer>()
            {
                new Customer()
                {
                CID = 1,
                cFirstname = "Liron",
                cLastname = "Himbert",
                cBirthday = System.DateTime.Now,
                cAddress = "Yeelim",
                cCity = "Beersheva",
                cEmail = "lironbenharrouch@gmail.com",
                cPassword = "screener158",
                cIsVip = true,
                cType = "Admin"
                },
                new Customer()
                {
                CID = 2,
                cFirstname = "Tal",
                cLastname = "Mimouni",
                cBirthday = System.DateTime.Now,
                cAddress = "Ahalutz",
                cCity = "Beersheva",
                cEmail = "talmimouni@gmail.com",
                cPassword = "tali123",
                cIsVip = false,
                cType = "Barista"
                },
                new Customer()
                {
                CID = 3,
                cFirstname = "Ilan",
                cLastname = "Malka",
                cBirthday = System.DateTime.Now,
                cAddress = "Bazel",
                cCity = "Beersheva",
                cEmail = "ilanmalka@gmail.com",
                cPassword = "king12312",
                cIsVip = false,
                cType = "Client"
                }

            };
            ViewBag.Customers = customers;
            return View();
        }

    }
}
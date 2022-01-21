using MCOF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCOF.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult GetAdmin()
        {
            var admins = new List<Admin>()
            {
                new Admin()
                { 
                    AID = 1,
                    aFirstname = "Liron",
                    aLastname = "Himbert",
                    aEmail = "lironbenharrouch@gmail.com",
                    aPassword = "bibi123",
                    BranchName = "BeerSheva"
                },
                new Admin()
                {
                    AID = 2,
                    aFirstname = "Tal",
                    aLastname = "Mimouni",
                    aEmail = "talminouni1@gmail.com",
                    aPassword = "Parisclavie",
                    BranchName = "TelAviv"
                }

            };
            return View(admins);
        }
    }
}
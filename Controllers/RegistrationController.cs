using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCupOverflows.Models;
using System.Security.Cryptography;
using MyCupOverflows.Dal;

namespace MyCupOverflows.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public object WebSecurity { get; private set; }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)


        {
            if (ModelState.IsValid)
            {
                UserDal dal = new UserDal();
                AdminDal addal = new AdminDal();
                if (dal.Users.Where(s => s.Username.Equals(username) && s.Password.Equals(password)).Count() > 0)
                {
                    //add session
                    Session["USERNAME"] = dal.Users.Where(s => s.Username.Equals(username) && s.Password.Equals(password)).FirstOrDefault().Username;
                    Session["PASSWORD"] = dal.Users.Where(s => s.Username.Equals(username) && s.Password.Equals(password)).FirstOrDefault().Password;
                    return RedirectToAction("Home", "Home");
                }
                else if (addal.Admin.Where(s => s.Username.Equals(username) && s.Password.Equals(password)).Count() > 0)
                {
                    Session["USERNAME"] = addal.Admin.Where(s => s.Username.Equals(username) && s.Password.Equals(password)).FirstOrDefault().Username;
                    Session["PASSWORD"] = addal.Admin.Where(s => s.Username.Equals(username) && s.Password.Equals(password)).FirstOrDefault().Password;
                    return RedirectToAction("SlideMenu", "Admin");
                }
            }

            return View();
        }
        // GET: Register
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(User obj)

        {
            if (ModelState.IsValid)
            {
                UserDal dal = new UserDal();
                dal.Users.Add(obj);
                dal.SaveChanges();
                return View("Login");

            }
            return View();
        }


        // Post: /Account/ForgotPassword

        [HttpGet]
        public ActionResult ForgetPassWord(string dt)
        {
            using (UserDal dc = new UserDal())
            {
                var v = dc.Users.Where(a => a.Username == dt).FirstOrDefault();
                return View(v);
            }
        }

        [HttpPost]
        public ActionResult ForgetPassWord(User userT)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (UserDal dc = new UserDal())
                {
                    if (userT.Id != null)
                    {
                        //Edit 
                        var v = dc.Users.Where(a => a.Id == userT.Id).FirstOrDefault();
                        if (v != null)
                        {
                            v.Password = userT.Password;
                            v.ConfirmPassword = userT.ConfirmPassword;

                        }
                    }
                    else
                    {
                        //Save
                        dc.Users.Add(userT);
                    }
                    dc.SaveChanges();
                    status = true;
                    return View("Login");

                }
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}
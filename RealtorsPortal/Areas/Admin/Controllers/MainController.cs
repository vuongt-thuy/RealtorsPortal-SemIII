using BusinessLogicLayer.Respositories;
using DataAccessLayer.Models.Entities;
using RealtorsPortal.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealtorsPortal.Areas.Admin.Controllers
{
    public class MainController : Controller
    {
        private Respository<User> resUser;

        public MainController()
        {
            resUser = new Respository<User>();
        }

        // GET: Admin/Main
        public ActionResult Login()
        {
            if (Response.Cookies["admin"].Value == null)
            //if(Session["admin"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Dashboard");
            }
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var user = resUser.GetOne(x => x.Email.Equals(email) && x.Password.Equals(password) && x.RoleId == SystemConstant.ADMIN);
            if (user != null)
            {
                Response.Cookies["admin"].Value = user.Username;
                Response.Cookies["user"].Expires = DateTime.Now.AddMinutes(10000000);
                //Session["admin"] = user;

                return RedirectToAction("Index", "Dashboard");
            }
            ViewBag.msg = "Incorrect account or password!";
            return View();

        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            //Session["admin"] = null;
            return RedirectToAction("Login");
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }
    }
}
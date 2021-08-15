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
            if (Session["admin"] == null)
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
            var user = resUser.GetOne(x => x.Email.Equals(email) && x.Password.Equals(password) && x.RoleId == SystemConstant.ADMIN && x.Active == true);
            if (user != null)
            {
                Session["admin"] = user;
                return RedirectToAction("Index", "Dashboard");
            }
            ViewBag.msg = "Incorrect account or password!";
            return View();

        }

        public ActionResult Logout()
        {
            Session["admin"] = null;
            return RedirectToAction("Login");
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }
    }
}
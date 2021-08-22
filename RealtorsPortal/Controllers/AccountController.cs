using BusinessLogicLayer.Respositories;
using DataAccessLayer.Models.Entities;
using DataAccessLayer.Models.ViewModel;
using RealtorsPortal.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace RealtorsPortal.Controllers
{
    public class AccountController : Controller
    {
        private Respository<User> resUser;

        public AccountController()
        {
            resUser = new Respository<User>();
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var user = resUser.GetOne(x => x.Email.Equals(email) && x.Password.Equals(password) && x.Active == true);
            if (user != null)
            {
                Session["user"] = user;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.msg = "Incorrect email or password!";
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserViewModel _user)
        {
            if (ModelState.IsValid)
            {
                if(!resUser.CheckDuplicate(x => x.Email.Equals(_user.Email))) {
                    User user = new User();
                    user.Fullname = _user.Fullname;
                    user.Username = _user.Username;
                    user.Phone = _user.Phone;
                    user.Email = _user.Email;
                    user.Password = _user.Password;
                    user.Active = true;
                    user.RoleId = SystemConstant.VISITOR;
                    user.Birthday = null;
                    user.CreatedAt = DateTime.Now;
                    user.UpdatedAt = DateTime.Now;

                    if (resUser.Create(user))
                    {
                        SendEmail.Notification(user.Email, 
                                       "Account Registration Confirmation",
                                       "You have successfully registered an account!" + " Account " + " Email: " + user.Email + " Password: " + user.Password);
                        return RedirectToRoute("User_Login");
                    }
                } else
                {
                    ModelState.AddModelError("Email", "Email already exists!");
                    return View(_user);
                }                
            }
            return View(_user);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Login");
        }
    }
}
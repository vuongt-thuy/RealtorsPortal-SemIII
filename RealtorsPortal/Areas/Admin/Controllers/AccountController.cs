using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealtorsPortal.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminUsers()
        {
            return View("AdminUsers/Index");
        }

        public ActionResult PrivateSellers()
        {
            return View("PrivateSellers/Index");
        }

        public ActionResult Agents()
        {
            return View("Agents/Index");
        }
    }
}
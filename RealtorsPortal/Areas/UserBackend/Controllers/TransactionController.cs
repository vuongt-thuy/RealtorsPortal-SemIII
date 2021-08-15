using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealtorsPortal.Areas.UserBackend.Controllers
{
    public class TransactionController : Controller
    {
        // GET: UserBackend/Transaction
        public ActionResult Index()
        {
            return RedirectToAction("History");
        }

        public ActionResult History()
        {
            return View();
        }
    }
}
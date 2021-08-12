using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealtorsPortal.Areas.Admin.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Admin/Statistic
        public ActionResult Category()
        {
            return View();
        }

        public ActionResult User()
        {
            return View();
        }
        public ActionResult Payment()
        {
            return View();
        }

        public ActionResult Ads()
        {
            return View();
        }
    }
}
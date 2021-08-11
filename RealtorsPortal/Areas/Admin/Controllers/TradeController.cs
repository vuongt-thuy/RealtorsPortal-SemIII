using RealtorsPortal.Areas.Admin.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealtorsPortal.Areas.Admin.Controllers
{
    [CustomeAuthentication]
    public class TradeController : Controller
    {
        // GET: Admin/Trade
        public ActionResult Index()
        {
            return View();
        }

        //[ActionName("Edit")]
        public ActionResult EditAgent()
        {
            return View("EditAgent");
        }

        //[ActionName("Edit")]
        public ActionResult EditPrivateSeller()
        {
            return View("EditPrivateSeller");
        }
    }
}
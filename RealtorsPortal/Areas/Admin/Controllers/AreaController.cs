using RealtorsPortal.Areas.Admin.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealtorsPortal.Areas.Admin.Controllers
{
    [CustomeAuthentication]
    public class AreaController : Controller
    {
        // GET: Admin/Area
        public ActionResult Index()
        {
            return View();
        }
    }
}